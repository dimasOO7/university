namespace lab6;

partial class MainMenu
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        GuessAnswerButton = new Button();
        button1 = new Button();
        button3 = new Button();
        ArraySortButton = new Button();
        button5 = new Button();
        ExitButton = new Button();
        SuspendLayout();
        // 
        // GuessAnswerButton
        // 
        GuessAnswerButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        GuessAnswerButton.FlatStyle = FlatStyle.System;
        GuessAnswerButton.Font = new Font("Segoe UI", 24F);
        GuessAnswerButton.Location = new Point(15, 15);
        GuessAnswerButton.Margin = new Padding(6);
        GuessAnswerButton.MaximumSize = new Size(10000, 100000);
        GuessAnswerButton.MinimumSize = new Size(100, 50);
        GuessAnswerButton.Name = "GuessAnswerButton";
        GuessAnswerButton.Size = new Size(694, 110);
        GuessAnswerButton.TabIndex = 1;
        GuessAnswerButton.Text = "угадай ответ";
        GuessAnswerButton.UseVisualStyleBackColor = true;
        GuessAnswerButton.Click += GuessAnswerButton_click;
        // 
        // button1
        // 
        button1.Font = new Font("Segoe UI", 24F);
        button1.Location = new Point(15, 381);
        button1.Margin = new Padding(6);
        button1.Name = "button1";
        button1.Size = new Size(694, 110);
        button1.TabIndex = 2;
        button1.Text = "червяк";
        button1.UseVisualStyleBackColor = true;
        // 
        // button3
        // 
        button3.Font = new Font("Segoe UI", 24F);
        button3.Location = new Point(15, 137);
        button3.Margin = new Padding(6);
        button3.Name = "button3";
        button3.Size = new Size(694, 110);
        button3.TabIndex = 3;
        button3.Text = "математический тест";
        button3.UseVisualStyleBackColor = true;
        // 
        // ArraySortButton
        // 
        ArraySortButton.Font = new Font("Segoe UI", 24F);
        ArraySortButton.Location = new Point(15, 259);
        ArraySortButton.Margin = new Padding(6);
        ArraySortButton.Name = "ArraySortButton";
        ArraySortButton.Size = new Size(694, 110);
        ArraySortButton.TabIndex = 4;
        ArraySortButton.Text = "сортировка массивов";
        ArraySortButton.UseVisualStyleBackColor = true;
        ArraySortButton.Click += ArraySortButton_Click;
        // 
        // button5
        // 
        button5.Font = new Font("Segoe UI", 24F);
        button5.Location = new Point(15, 503);
        button5.Margin = new Padding(6);
        button5.Name = "button5";
        button5.Size = new Size(694, 110);
        button5.TabIndex = 5;
        button5.Text = "Об Авторе";
        button5.UseVisualStyleBackColor = true;
        button5.Click += About_click;
        // 
        // ExitButton
        // 
        ExitButton.Font = new Font("Segoe UI", 24F);
        ExitButton.Location = new Point(15, 625);
        ExitButton.Margin = new Padding(6);
        ExitButton.Name = "ExitButton";
        ExitButton.Size = new Size(694, 110);
        ExitButton.TabIndex = 6;
        ExitButton.Text = "Выход";
        ExitButton.UseVisualStyleBackColor = true;
        ExitButton.Click += ExitButton_click;
        // 
        // MainMenu
        // 
        AutoScaleDimensions = new SizeF(192F, 192F);
        AutoScaleMode = AutoScaleMode.Dpi;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ClientSize = new Size(974, 929);
        Controls.Add(ExitButton);
        Controls.Add(button5);
        Controls.Add(ArraySortButton);
        Controls.Add(button3);
        Controls.Add(button1);
        Controls.Add(GuessAnswerButton);
        Margin = new Padding(4, 2, 4, 2);
        Name = "MainMenu";
        RightToLeft = RightToLeft.Yes;
        Text = "Main Menu";
        Load += Form1_Load;
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button ArraySortButton;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Button ExitButton;

    private System.Windows.Forms.Button GuessAnswerButton;

    #endregion
}