namespace LabWork2
{
    partial class Form1
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            заданиеToolStripMenuItem = new ToolStripMenuItem();
            CreateListToolStripMenuItem = new ToolStripMenuItem();
            f1CreateToolStripMenuItem1 = new ToolStripMenuItem();
            f2CreateToolStripMenuItem1 = new ToolStripMenuItem();
            f3CreateToolStripMenuItem1 = new ToolStripMenuItem();
            редактированиеСпискаToolStripMenuItem = new ToolStripMenuItem();
            добавлениеЭлементаToolStripMenuItem = new ToolStripMenuItem();
            InsertBeforeFirstToolStripMenuItem = new ToolStripMenuItem();
            InsertInEndToolStripMenuItem = new ToolStripMenuItem();
            InsertToolStripMenuItem = new ToolStripMenuItem();
            удалениеЭлементаToolStripMenuItem = new ToolStripMenuItem();
            DeleteFirstToolStripMenuItem = new ToolStripMenuItem();
            DeleteLastToolStripMenuItem = new ToolStripMenuItem();
            DeleteAtToolStripMenuItem = new ToolStripMenuItem();
            ProcessingToolStripMenuItem = new ToolStripMenuItem();
            показатьToolStripMenuItem = new ToolStripMenuItem();
            f1ToolStripMenuItem = new ToolStripMenuItem();
            f2ToolStripMenuItem = new ToolStripMenuItem();
            f3ToolStripMenuItem = new ToolStripMenuItem();
            DestroyToolStripMenuItem = new ToolStripMenuItem();
            f1DestroyToolStripMenuItem1 = new ToolStripMenuItem();
            f2DestroyToolStripMenuItem1 = new ToolStripMenuItem();
            f3DestroyToolStripMenuItem1 = new ToolStripMenuItem();
            AboutToolStripMenuItem = new ToolStripMenuItem();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { заданиеToolStripMenuItem, AboutToolStripMenuItem, ExitToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(3, 1, 0, 1);
            menuStrip1.Size = new Size(740, 38);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // заданиеToolStripMenuItem
            // 
            заданиеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { CreateListToolStripMenuItem, редактированиеСпискаToolStripMenuItem, ProcessingToolStripMenuItem, показатьToolStripMenuItem, DestroyToolStripMenuItem });
            заданиеToolStripMenuItem.Name = "заданиеToolStripMenuItem";
            заданиеToolStripMenuItem.Size = new Size(125, 36);
            заданиеToolStripMenuItem.Text = "Задание";
            // 
            // CreateListToolStripMenuItem
            // 
            CreateListToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { f1CreateToolStripMenuItem1, f2CreateToolStripMenuItem1, f3CreateToolStripMenuItem1 });
            CreateListToolStripMenuItem.Name = "CreateListToolStripMenuItem";
            CreateListToolStripMenuItem.Size = new Size(409, 44);
            CreateListToolStripMenuItem.Text = "Создание списка";
            // 
            // f1CreateToolStripMenuItem1
            // 
            f1CreateToolStripMenuItem1.Name = "f1CreateToolStripMenuItem1";
            f1CreateToolStripMenuItem1.Size = new Size(172, 44);
            f1CreateToolStripMenuItem1.Text = "F1";
            f1CreateToolStripMenuItem1.Click += f1CreateToolStripMenuItem1_Click;
            // 
            // f2CreateToolStripMenuItem1
            // 
            f2CreateToolStripMenuItem1.Name = "f2CreateToolStripMenuItem1";
            f2CreateToolStripMenuItem1.Size = new Size(172, 44);
            f2CreateToolStripMenuItem1.Text = "F2";
            f2CreateToolStripMenuItem1.Click += f2CreateToolStripMenuItem1_Click;
            // 
            // f3CreateToolStripMenuItem1
            // 
            f3CreateToolStripMenuItem1.Name = "f3CreateToolStripMenuItem1";
            f3CreateToolStripMenuItem1.Size = new Size(172, 44);
            f3CreateToolStripMenuItem1.Text = "F3";
            f3CreateToolStripMenuItem1.Click += f3CreateToolStripMenuItem1_Click;
            // 
            // редактированиеСпискаToolStripMenuItem
            // 
            редактированиеСпискаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { добавлениеЭлементаToolStripMenuItem, удалениеЭлементаToolStripMenuItem });
            редактированиеСпискаToolStripMenuItem.Name = "редактированиеСпискаToolStripMenuItem";
            редактированиеСпискаToolStripMenuItem.Size = new Size(409, 44);
            редактированиеСпискаToolStripMenuItem.Text = "Редактирование списка";
            // 
            // добавлениеЭлементаToolStripMenuItem
            // 
            добавлениеЭлементаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { InsertBeforeFirstToolStripMenuItem, InsertInEndToolStripMenuItem, InsertToolStripMenuItem });
            добавлениеЭлементаToolStripMenuItem.Name = "добавлениеЭлементаToolStripMenuItem";
            добавлениеЭлементаToolStripMenuItem.Size = new Size(394, 44);
            добавлениеЭлементаToolStripMenuItem.Text = "Добавление элемента";
            // 
            // InsertBeforeFirstToolStripMenuItem
            // 
            InsertBeforeFirstToolStripMenuItem.Name = "InsertBeforeFirstToolStripMenuItem";
            InsertBeforeFirstToolStripMenuItem.Size = new Size(333, 44);
            InsertBeforeFirstToolStripMenuItem.Text = "В начало";
            InsertBeforeFirstToolStripMenuItem.Click += InsertBeforeFirstToolStripMenuItem_Click;
            // 
            // InsertInEndToolStripMenuItem
            // 
            InsertInEndToolStripMenuItem.Name = "InsertInEndToolStripMenuItem";
            InsertInEndToolStripMenuItem.Size = new Size(333, 44);
            InsertInEndToolStripMenuItem.Text = "В конец";
            InsertInEndToolStripMenuItem.Click += InsertInEndToolStripMenuItem_Click;
            // 
            // InsertToolStripMenuItem
            // 
            InsertToolStripMenuItem.Name = "InsertToolStripMenuItem";
            InsertToolStripMenuItem.Size = new Size(333, 44);
            InsertToolStripMenuItem.Text = "В произвольную";
            InsertToolStripMenuItem.Click += InsertToolStripMenuItem_Click;
            // 
            // удалениеЭлементаToolStripMenuItem
            // 
            удалениеЭлементаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { DeleteFirstToolStripMenuItem, DeleteLastToolStripMenuItem, DeleteAtToolStripMenuItem });
            удалениеЭлементаToolStripMenuItem.Name = "удалениеЭлементаToolStripMenuItem";
            удалениеЭлементаToolStripMenuItem.Size = new Size(394, 44);
            удалениеЭлементаToolStripMenuItem.Text = "Удаление элемента";
            // 
            // DeleteFirstToolStripMenuItem
            // 
            DeleteFirstToolStripMenuItem.Name = "DeleteFirstToolStripMenuItem";
            DeleteFirstToolStripMenuItem.Size = new Size(320, 44);
            DeleteFirstToolStripMenuItem.Text = "Первого";
            DeleteFirstToolStripMenuItem.Click += DeleteFirstToolStripMenuItem_Click;
            // 
            // DeleteLastToolStripMenuItem
            // 
            DeleteLastToolStripMenuItem.Name = "DeleteLastToolStripMenuItem";
            DeleteLastToolStripMenuItem.Size = new Size(320, 44);
            DeleteLastToolStripMenuItem.Text = "Последнего";
            DeleteLastToolStripMenuItem.Click += DeleteLastToolStripMenuItem_Click;
            // 
            // DeleteAtToolStripMenuItem
            // 
            DeleteAtToolStripMenuItem.Name = "DeleteAtToolStripMenuItem";
            DeleteAtToolStripMenuItem.Size = new Size(320, 44);
            DeleteAtToolStripMenuItem.Text = "Произвольного";
            DeleteAtToolStripMenuItem.Click += DeleteAtToolStripMenuItem_Click;
            // 
            // ProcessingToolStripMenuItem
            // 
            ProcessingToolStripMenuItem.Name = "ProcessingToolStripMenuItem";
            ProcessingToolStripMenuItem.Size = new Size(409, 44);
            ProcessingToolStripMenuItem.Text = "Обработка";
            ProcessingToolStripMenuItem.Click += ProcessingToolStripMenuItem_Click;
            // 
            // показатьToolStripMenuItem
            // 
            показатьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { f1ToolStripMenuItem, f2ToolStripMenuItem, f3ToolStripMenuItem });
            показатьToolStripMenuItem.Name = "показатьToolStripMenuItem";
            показатьToolStripMenuItem.Size = new Size(409, 44);
            показатьToolStripMenuItem.Text = "Показать";
            // 
            // f1ToolStripMenuItem
            // 
            f1ToolStripMenuItem.Name = "f1ToolStripMenuItem";
            f1ToolStripMenuItem.Size = new Size(172, 44);
            f1ToolStripMenuItem.Text = "F1";
            f1ToolStripMenuItem.Click += f1ToolStripMenuItem_Click;
            // 
            // f2ToolStripMenuItem
            // 
            f2ToolStripMenuItem.Name = "f2ToolStripMenuItem";
            f2ToolStripMenuItem.Size = new Size(172, 44);
            f2ToolStripMenuItem.Text = "F2";
            f2ToolStripMenuItem.Click += f2ToolStripMenuItem_Click;
            // 
            // f3ToolStripMenuItem
            // 
            f3ToolStripMenuItem.Name = "f3ToolStripMenuItem";
            f3ToolStripMenuItem.Size = new Size(172, 44);
            f3ToolStripMenuItem.Text = "F3";
            f3ToolStripMenuItem.Click += f3ToolStripMenuItem_Click;
            // 
            // DestroyToolStripMenuItem
            // 
            DestroyToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { f1DestroyToolStripMenuItem1, f2DestroyToolStripMenuItem1, f3DestroyToolStripMenuItem1 });
            DestroyToolStripMenuItem.Name = "DestroyToolStripMenuItem";
            DestroyToolStripMenuItem.Size = new Size(409, 44);
            DestroyToolStripMenuItem.Text = "Разрушение";
            DestroyToolStripMenuItem.Click += DestroyToolStripMenuItem_Click;
            // 
            // f1DestroyToolStripMenuItem1
            // 
            f1DestroyToolStripMenuItem1.Name = "f1DestroyToolStripMenuItem1";
            f1DestroyToolStripMenuItem1.Size = new Size(359, 44);
            f1DestroyToolStripMenuItem1.Text = "F1";
            f1DestroyToolStripMenuItem1.Click += f1DestroyToolStripMenuItem1_Click;
            // 
            // f2DestroyToolStripMenuItem1
            // 
            f2DestroyToolStripMenuItem1.Name = "f2DestroyToolStripMenuItem1";
            f2DestroyToolStripMenuItem1.Size = new Size(359, 44);
            f2DestroyToolStripMenuItem1.Text = "F2";
            f2DestroyToolStripMenuItem1.Click += f2DestroyToolStripMenuItem1_Click;
            // 
            // f3DestroyToolStripMenuItem1
            // 
            f3DestroyToolStripMenuItem1.Name = "f3DestroyToolStripMenuItem1";
            f3DestroyToolStripMenuItem1.Size = new Size(359, 44);
            f3DestroyToolStripMenuItem1.Text = "F3";
            f3DestroyToolStripMenuItem1.Click += f3DestroyToolStripMenuItem1_Click;
            // 
            // AboutToolStripMenuItem
            // 
            AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            AboutToolStripMenuItem.Size = new Size(183, 36);
            AboutToolStripMenuItem.Text = "О программе";
            AboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(103, 36);
            ExitToolStripMenuItem.Text = "Выход";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(0, 38);
            label1.Name = "label1";
            label1.Size = new Size(668, 288);
            label1.TabIndex = 1;
            label1.Text = "Лабалаторная работа №2\r\nВариант 25\r\nКузнецов Дмитрий\r\n\r\n";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 261);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 9F);
            Name = "Form1";
            Text = "Лабалаторная работа 2";
            FormClosing += Form1_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem заданиеToolStripMenuItem;
        private ToolStripMenuItem CreateListToolStripMenuItem;
        private ToolStripMenuItem редактированиеСпискаToolStripMenuItem;
        private ToolStripMenuItem ProcessingToolStripMenuItem;
        private ToolStripMenuItem DestroyToolStripMenuItem;
        private ToolStripMenuItem AboutToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private ToolStripMenuItem добавлениеЭлементаToolStripMenuItem;
        private ToolStripMenuItem InsertBeforeFirstToolStripMenuItem;
        private ToolStripMenuItem InsertInEndToolStripMenuItem;
        private ToolStripMenuItem InsertToolStripMenuItem;
        private ToolStripMenuItem удалениеЭлементаToolStripMenuItem;
        private ToolStripMenuItem DeleteFirstToolStripMenuItem;
        private ToolStripMenuItem DeleteLastToolStripMenuItem;
        private ToolStripMenuItem DeleteAtToolStripMenuItem;
        private ToolStripMenuItem показатьToolStripMenuItem;
        private ToolStripMenuItem f1ToolStripMenuItem;
        private ToolStripMenuItem f2ToolStripMenuItem;
        private ToolStripMenuItem f3ToolStripMenuItem;
        private ToolStripMenuItem f1CreateToolStripMenuItem1;
        private ToolStripMenuItem f2CreateToolStripMenuItem1;
        private ToolStripMenuItem f3CreateToolStripMenuItem1;
        private ToolStripMenuItem f1DestroyToolStripMenuItem1;
        private ToolStripMenuItem f2DestroyToolStripMenuItem1;
        private ToolStripMenuItem f3DestroyToolStripMenuItem1;
        private Label label1;
    }
}
