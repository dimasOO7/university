namespace lab6
{
    partial class SnakeGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            components = new System.ComponentModel.Container();
            GameTimer = new System.Windows.Forms.Timer(components);
            world = new PictureBox();
            ResultLabel = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)world).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // GameTimer
            // 
            GameTimer.Tick += GameTimer_Tick;
            // 
            // world
            // 
            world.Location = new Point(3, 98);
            world.Name = "world";
            world.Size = new Size(1479, 114);
            world.TabIndex = 0;
            world.TabStop = false;
            world.Paint += world_Paint;
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Font = new Font("Segoe UI", 24F);
            ResultLabel.Location = new Point(3, 0);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(384, 86);
            ResultLabel.TabIndex = 1;
            ResultLabel.Text = "Результат: 0";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(ResultLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(world, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 95F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(1479, 1270);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // SnakeGameForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1479, 1270);
            Controls.Add(tableLayoutPanel1);
            Name = "SnakeGameForm";
            Text = "SnakeGameForm";
            ((System.ComponentModel.ISupportInitialize)world).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer GameTimer;
        private PictureBox world;
        private Label ResultLabel;
        private TableLayoutPanel tableLayoutPanel1;
    }
}