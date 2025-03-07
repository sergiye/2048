using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

namespace u2048 {

  internal class Game {
  
    private class Button {
      private readonly SolidBrush brush;
      private readonly string text;
      private readonly Rectangle bounds;

      public int X => bounds.X;
      public int Y => bounds.Y;
      public int Width => bounds.Width;
      public int Height => bounds.Height;
      
      public Action<Button> OnClick { get; }

      public Button(int x, int y, int width, int height, Color color, string text = null, Action<Button> onClick = null) {
        bounds = new Rectangle(x, y, width, height);
        
        OnClick = onClick;
        brush = new SolidBrush(color);
        this.text = text;
      }

      public virtual void Draw(Graphics g) {
        g.FillRoundedRectangle(brush, bounds, 5);
        if (!string.IsNullOrEmpty(text)) {
          g.DrawTextCenterWs(text, buttonFont, defaultBrush, whiteBrush, X + Width / 2, Y + Height / 2);
        }
      }
    }
    
    private class ImageButton: Button {
      private readonly Bitmap imageOn;
      private readonly Bitmap imageOff;

      public bool TurnedOn {get; set; }

      public ImageButton(int x, int y, int width, int height, Bitmap image1, Bitmap image2, Action<Button> onClick = null) : 
        base(x, y, width, height, Color.Transparent, null, onClick) {

        TurnedOn = true;
        this.imageOn = image1;
        this.imageOff = image2;
      }

      public override void Draw(Graphics g) {
        g.DrawImage(TurnedOn ? imageOn : imageOff, new Point(X, Y));
      }
    }

    private class HistoryItem {
      
      public HistoryItem(int[][] board, int score) {
        Board = board;
        Score = score;
      }

      public int[][] Board { get; }
      public int Score { get; }
    }
    
    private static readonly Font buttonFont = new Font("Clear Sans", 10, FontStyle.Bold);
    private static readonly Font scoreFont = new Font("Clear Sans", 12, FontStyle.Bold);
    private static readonly SolidBrush boardBrush = new SolidBrush(Color.FromArgb(187, 173, 160));
    private static readonly SolidBrush defaultBrush = new SolidBrush(Color.FromArgb(64, 10, 10, 10));
    private static readonly SolidBrush defaultBrush2 = new SolidBrush(Color.FromArgb(120, 110, 101));
    private static readonly SolidBrush scoreBrush = new SolidBrush(Color.LightGoldenrodYellow);
    private static readonly SolidBrush whiteBrush = new SolidBrush(Color.White);

    private WMPLib.WindowsMediaPlayer player;
    private readonly List<Button> buttons = new List<Button>();
    private readonly ImageButton soundButton;
    private static string mainThemeFilePath;
    private readonly Random oR = new Random();

    private bool musicEnabled = true;
    private int addNum;
    private bool gameOver;
    private int newX = -1;
    private int newY = -1;
    private readonly List<HistoryItem> history = new List<HistoryItem>();

    public int Best { get; set; }
    public int BoardSize { get; private set; }
    public int[][] Board { get; private set; }
    public int Score { get; private set; }

    public enum Direction {
      Top,
      Right,
      Bottom,
      Left,
    };

    public Game() {

      buttons.Add(new Button(18, 24, 100, 60, Color.FromArgb(0xb8, 0xad, 0xa0))); // -- SCORE
      buttons.Add(new Button(126, 24, 100, 60, Color.FromArgb(0xb8, 0xad, 0xa0))); // -- BEST

      soundButton = new ImageButton(327, 40, 44, 36, 
        new Bitmap(GetStreamFromResource("images.soundOn.png")), 
        new Bitmap(GetStreamFromResource("images.soundOff.png")), 
        (b) => { MusicEnabled = !MusicEnabled; });
      buttons.Add(soundButton);

      buttons.Add(new Button(233, 27, 90, 26, Color.FromArgb(0xed, 0x99, 0x5b), "RESTART", (b) => StartNewGame(this.BoardSize)));
      buttons.Add(new Button(233, 57, 90, 26, Color.FromArgb(184, 131, 242), "Undo", (b) => UndoMove()));

      mainThemeFilePath = Path.Combine(Path.GetTempPath(), "2048_main_theme.mp3"); //"sounds/main_theme.mp3"
      try {
        using (var mainThemeStream = GetStreamFromResource("sounds.main_theme.mp3"))
        using (var fileStream = File.Create(mainThemeFilePath)) {
          mainThemeStream.Seek(0, SeekOrigin.Begin);
          mainThemeStream.CopyTo(fileStream);
        }
      }
      catch (Exception) {
        // ignored
      }
    }

    public bool MusicEnabled {
      get => musicEnabled;
      set {
        if (musicEnabled == value) return;
        musicEnabled = value;
        soundButton.TurnedOn = MusicEnabled;
        if (musicEnabled)
          PlayMainTheme();
        else
          StopMainTheme();
      }
    }

    public void Update() {
      while (!gameOver && addNum > 0) {
        int nX = oR.Next(0, BoardSize), nY = oR.Next(0, BoardSize);

        if (Board[nX][nY] == 0) {
          Board[nX][nY] = oR.Next(0, 20) == 0 ? oR.Next(0, 15) == 0 ? 8 : 4 : 2;
          newX = nX;
          newY = nY;
          --addNum;
        }
      }
    }

    public void Draw(Graphics g) {
      DrawGame(g);
      if (gameOver) {
        GameOverDraw(g);
      }
    }

    private void DrawGame(Graphics g) {
      foreach (var b in buttons) {
        b.Draw(g);
      }

      g.DrawTextCenterXws("SCORE", buttonFont, defaultBrush, scoreBrush, 68, 32);
      g.DrawTextCenterXws(Score.ToString(), scoreFont, defaultBrush, whiteBrush, 68, 54);

      g.DrawTextCenterXws("BEST", buttonFont, defaultBrush, scoreBrush, 176, 32);
      g.DrawTextCenterXws(Best.ToString(), scoreFont, defaultBrush, whiteBrush, 176, 54);

      g.FillRoundedRectangle(boardBrush, new Rectangle(18, 92, BoardSize * 88, BoardSize * 88), 5);

      for (var i = 0; i < BoardSize; i++) {
        for (var j = 0; j < BoardSize; j++) {
          g.FillRoundedRectangle(new SolidBrush(getCellColor(Board[i][j], i == newX && j == newY)), new Rectangle(25 + 87 * i, 100 + 87 * j, 76, 76), 5);
          if (Board[i][j] > 0) {
            g.DrawTextCenterWs(Board[i][j].ToString(), new Font("Clear Sans", GetFontSize(Board[i][j]), FontStyle.Bold), defaultBrush, 
              (i == newX && j == newY ? whiteBrush : Board[i][j] < 8 ? defaultBrush2 : new SolidBrush(Color.FromArgb(249, 245, 235))),
              63 + 87 * i, 139 + 87 * j);
          }
        }
      }
    }

    private void GameOverDraw(Graphics g) {
      g.FillRectangle(new SolidBrush(Color.FromArgb(150, 251, 248, 239)), g.VisibleClipBounds);
     
      g.DrawTextCenterXws("GAME OVER", scoreFont, defaultBrush, defaultBrush2, 198, 250);
      g.DrawTextCenterXws($"SCORE: {Score}", scoreFont, defaultBrush, defaultBrush2, 198, 282);
    }
    
    private Stream GetStreamFromResource(string resourceName) {
      var type = this.GetType();
      var assembly = Assembly.GetAssembly(type);
      var scriptsPath = $"{type.Namespace}.{resourceName}";
      return assembly.GetManifestResourceStream(scriptsPath);
    }
    
    private void PlayMainTheme() {
      if (gameOver || player == null && File.Exists(mainThemeFilePath)) {
        player = new WMPLib.WindowsMediaPlayer();
        player.PlayStateChange += state => {
          if (state == (int)WMPLib.WMPPlayState.wmppsStopped)
            player.controls.play();
        };
        player.URL = mainThemeFilePath;
      }

      player?.controls.play();
    }

    private void StopMainTheme() {
      player?.controls.pause();
    }
        
    private void PlayGameOverSound() {
      using (var p = new System.Media.SoundPlayer(GetStreamFromResource("sounds.game_over.wav"))) {
        p.Play();
      }
    }

    private void PlayWhipSound() {
      using (var p = new System.Media.SoundPlayer(GetStreamFromResource("sounds.whip.wav"))) {
        p.Play();
      }
    }

    private int[][] GetBoardCopy() {
      var copy = new int[BoardSize][]; 
      for (var i = 0; i < BoardSize; i++) {
        copy[i] = new int[BoardSize];
        Board[i].CopyTo(copy[i], 0);
      }
      return copy;
    }
    
    private void AddToHistory(int[][] arrCopy, int score) {
      history.Add(new HistoryItem(arrCopy, score));
      while (history.Count > 100)
        history.RemoveAt(0);
    }
    
    public void MoveBoard(Direction nDirection) {
      
      var prevBoard = GetBoardCopy();
      var prevScore = Score;
      
      var bAdd = false;
      switch (nDirection) {
        case Direction.Top:
          for (var i = 0; i < BoardSize; i++) {
            for (var j = 0; j < BoardSize; j++) {
              for (var k = j + 1; k < BoardSize; k++) {
                if (Board[i][k] == 0)
                  continue;

                if (Board[i][k] == Board[i][j]) {
                  Board[i][j] *= 2;
                  Score += Board[i][j];
                  Board[i][k] = 0;
                  bAdd = true;
                  break;
                }

                if (Board[i][j] == 0 && Board[i][k] != 0) {
                  Board[i][j] = Board[i][k];
                  Board[i][k] = 0;
                  j--;
                  bAdd = true;
                  break;
                }

                if (Board[i][j] != 0)
                  break;
              }
            }
          }
          break;
        case Direction.Right:
          for (var j = 0; j < BoardSize; j++) {
            for (var i = BoardSize - 1; i >= 0; i--) {
              for (var k = i - 1; k >= 0; k--) {
                if (Board[k][j] == 0)
                  continue;

                if (Board[k][j] == Board[i][j]) {
                  Board[i][j] *= 2;
                  Score += Board[i][j];
                  Board[k][j] = 0;
                  bAdd = true;
                  break;
                }

                if (Board[i][j] == 0 && Board[k][j] != 0) {
                  Board[i][j] = Board[k][j];
                  Board[k][j] = 0;
                  i++;
                  bAdd = true;
                  break;
                }

                if (Board[i][j] != 0)
                  break;
              }
            }
          }
          break;
        case Direction.Bottom:
          for (var i = 0; i < BoardSize; i++) {
            for (var j = BoardSize - 1; j >= 0; j--) {
              for (var k = j - 1; k >= 0; k--) {
                if (Board[i][k] == 0)
                  continue;

                if (Board[i][k] == Board[i][j]) {
                  Board[i][j] *= 2;
                  Score += Board[i][j];
                  Board[i][k] = 0;
                  bAdd = true;
                  break;
                }
                if (Board[i][j] == 0 && Board[i][k] != 0) {
                  Board[i][j] = Board[i][k];
                  Board[i][k] = 0;
                  j++;
                  bAdd = true;
                  break;
                }

                if (Board[i][j] != 0)
                  break;
              }
            }
          }
          break;
        case Direction.Left:
          for (var j = 0; j < BoardSize; j++) {
            for (var i = 0; i < BoardSize; i++) {
              for (var k = i + 1; k < BoardSize; k++) {
                if (Board[k][j] == 0)
                  continue;

                if (Board[k][j] == Board[i][j]) {
                  Board[i][j] *= 2;
                  Score += Board[i][j];
                  Board[k][j] = 0;
                  bAdd = true;
                  break;
                }
                if (Board[i][j] == 0 && Board[k][j] != 0) {
                  Board[i][j] = Board[k][j];
                  Board[k][j] = 0;
                  i--;
                  bAdd = true;
                  break;
                }

                if (Board[i][j] != 0)
                  break;
              }
            }
          }
          break;
      }

      if (Score > Best) Best = Score;

      if (bAdd) {
        ++addNum;
        PlayWhipSound();
        AddToHistory(prevBoard, prevScore);
      }

      CheckGameOver();
    }

    private void CheckGameOver() {
      for (var i = 0; i < BoardSize; i++) {
        for (var j = 0; j < BoardSize; j++) {
          if (i - 1 >= 0) {
            if (Board[i - 1][j] == Board[i][j]) {
              return;
            }
          }

          if (i + 1 < BoardSize) {
            if (Board[i + 1][j] == Board[i][j]) {
              return;
            }
          }

          if (j - 1 >= 0) {
            if (Board[i][j - 1] == Board[i][j]) {
              return;
            }
          }

          if (j + 1 < BoardSize) {
            if (Board[i][j + 1] == Board[i][j]) {
              return;
            }
          }

          if (Board[i][j] == 0) {
            return;
          }
        }
      }

      gameOver = true;
      StopMainTheme();
      PlayGameOverSound();
    }

    private Color getCellColor(int iNum, bool isNew) {
      if (isNew)
        return Color.FromArgb(41, 174, 255);
      switch (iNum) {
        case 0:
          return Color.FromArgb(0xCC, 0xC0, 0xB4);
        case 2:
          return Color.FromArgb(0xEE, 0xE4, 0xDA);
        case 4:
          return Color.FromArgb(0xED, 0xE0, 0xC3);
        case 8:
          return Color.FromArgb(0xFE, 0xB7, 0x71);
        case 16:
          return Color.FromArgb(0xFF, 0xA2, 0x59);
        case 32:
          return Color.FromArgb(0xFF, 0x8F, 0x57);
        case 64:
          return Color.FromArgb(0xFF, 0x75, 0x31);
        case 128:
          return Color.FromArgb(0xF1, 0xCB, 0x66);
        case 256:
          return Color.FromArgb(0xF5, 0xC6, 0x56);
        case 512:
          return Color.FromArgb(0xF5, 0xC3, 0x41);
        case 1024:
          return Color.FromArgb(0xF7, 0xBE, 0x30);
        case 2048:
          return Color.Goldenrod;
        case 4096:
          return Color.FromArgb(183, 132, 171);
        default:
          return Color.FromArgb(170, 96, 166);
      }
    }

    private int GetFontSize(int cellValue) {
      return cellValue > 65536 ? 14 : cellValue > 8192 ? 16 : cellValue > 512 ? 18 : 22;
    }
    
    public bool CheckButton(int nXPos, int nYPos) {
      foreach (var b in buttons.Where(b => b.OnClick != null && nXPos >= b.X && nXPos <= b.X + b.Width && nYPos >= b.Y && nYPos <= b.Y + b.Height)) {
        b.OnClick(b);
        return true;
      }
      return false;
    }

    public void StartNewGame(int size, int lastScore = 0, int[][] data = null) {
      
      if (data == null)
        history.Clear();
      
      BoardSize = size;
      Board = new int[BoardSize][];
      for (var i = 0; i < BoardSize; i++) {
        Board[i] = new int[BoardSize];
      }

      for (var i = 0; i < BoardSize; i++) {
        for (var j = 0; j < BoardSize; j++) {
          Board[i][j] = data == null ? 0 : data[i][j];
        }
      }

      addNum = data == null ? 2 : 0;
      Score = lastScore;
      gameOver = false;
      PlayMainTheme();
    }
    
    public void UndoMove() {

      if (history.Count == 0) return;
      var lastIndex = history.Count - 1;
      Board = history[lastIndex].Board;
      addNum = 0;
      Score = history[lastIndex].Score;
      newX = -1;
      newY = -1;
      gameOver = false;
      history.RemoveAt(lastIndex);
      PlayWhipSound();
    }
    
  }
}
