namespace Многоугольники_2._1
{
    partial class Форма
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Выборка = new System.Windows.Forms.MenuStrip();
            this.Выбор = new System.Windows.Forms.ToolStripMenuItem();
            this.Квадрат = new System.Windows.Forms.ToolStripMenuItem();
            this.Круг = new System.Windows.Forms.ToolStripMenuItem();
            this.Треугольник = new System.Windows.Forms.ToolStripMenuItem();
            this.Выборка.SuspendLayout();
            this.SuspendLayout();
            // 
            // Выборка
            // 
            this.Выборка.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Выборка.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Выбор});
            this.Выборка.Location = new System.Drawing.Point(0, 0);
            this.Выборка.Name = "Выборка";
            this.Выборка.Size = new System.Drawing.Size(800, 28);
            this.Выборка.TabIndex = 0;
            this.Выборка.Text = "menuStrip1";
            // 
            // Выбор
            // 
            this.Выбор.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Квадрат,
            this.Круг,
            this.Треугольник});
            this.Выбор.Name = "Выбор";
            this.Выбор.Size = new System.Drawing.Size(71, 24);
            this.Выбор.Text = "Форма";
            // 
            // Квадрат
            // 
            this.Квадрат.Name = "Квадрат";
            this.Квадрат.Size = new System.Drawing.Size(224, 26);
            this.Квадрат.Text = "Квадрат";
            this.Квадрат.Click += new System.EventHandler(this.Квадрат_Click);
            // 
            // Круг
            // 
            this.Круг.Name = "Круг";
            this.Круг.Size = new System.Drawing.Size(224, 26);
            this.Круг.Text = "Круг";
            this.Круг.Click += new System.EventHandler(this.Круг_Click);
            // 
            // Треугольник
            // 
            this.Треугольник.Name = "Треугольник";
            this.Треугольник.Size = new System.Drawing.Size(224, 26);
            this.Треугольник.Text = "Треугольник";
            this.Треугольник.Click += new System.EventHandler(this.Треугольник_Click);
            // 
            // Форма
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Выборка);
            this.MainMenuStrip = this.Выборка;
            this.Name = "Форма";
            this.Text = "Форма";
            this.Load += new System.EventHandler(this.Форма_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Форма_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Форма_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Форма_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Форма_MouseUp);
            this.Выборка.ResumeLayout(false);
            this.Выборка.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem Выбор;
        private System.Windows.Forms.MenuStrip Выборка;
        private System.Windows.Forms.ToolStripMenuItem Квадрат;
        private System.Windows.Forms.ToolStripMenuItem Круг;
        private System.Windows.Forms.ToolStripMenuItem Треугольник;
    }
}

