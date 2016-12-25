namespace UiForms
{
    partial class Form1
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
            this.BtnStart = new System.Windows.Forms.Button();
            this.TbMessage = new System.Windows.Forms.TextBox();
            this.LbAll = new System.Windows.Forms.ListBox();
            this.SelectLbl = new System.Windows.Forms.Label();
            this.Choose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.LbSelected = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(15, 201);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 23);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "Start Training";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // TbMessage
            // 
            this.TbMessage.Location = new System.Drawing.Point(15, 230);
            this.TbMessage.Name = "TbMessage";
            this.TbMessage.Size = new System.Drawing.Size(195, 20);
            this.TbMessage.TabIndex = 1;
            // 
            // LbAll
            // 
            this.LbAll.FormattingEnabled = true;
            this.LbAll.Location = new System.Drawing.Point(12, 35);
            this.LbAll.Name = "LbAll";
            this.LbAll.Size = new System.Drawing.Size(140, 160);
            this.LbAll.TabIndex = 2;
            // 
            // SelectLbl
            // 
            this.SelectLbl.AutoSize = true;
            this.SelectLbl.Location = new System.Drawing.Point(12, 13);
            this.SelectLbl.Name = "SelectLbl";
            this.SelectLbl.Size = new System.Drawing.Size(140, 13);
            this.SelectLbl.TabIndex = 3;
            this.SelectLbl.Text = "Select exercises before start";
            // 
            // Choose
            // 
            this.Choose.Location = new System.Drawing.Point(159, 81);
            this.Choose.Name = "Choose";
            this.Choose.Size = new System.Drawing.Size(51, 23);
            this.Choose.TabIndex = 4;
            this.Choose.Text = ">";
            this.Choose.UseVisualStyleBackColor = true;
            this.Choose.Click += new System.EventHandler(this.Choose_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LbSelected
            // 
            this.LbSelected.FormattingEnabled = true;
            this.LbSelected.Location = new System.Drawing.Point(216, 35);
            this.LbSelected.Name = "LbSelected";
            this.LbSelected.Size = new System.Drawing.Size(140, 160);
            this.LbSelected.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Selected";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 304);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LbSelected);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Choose);
            this.Controls.Add(this.SelectLbl);
            this.Controls.Add(this.LbAll);
            this.Controls.Add(this.TbMessage);
            this.Controls.Add(this.BtnStart);
            this.Name = "Form1";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.TextBox TbMessage;
        private System.Windows.Forms.ListBox LbAll;
        private System.Windows.Forms.Label SelectLbl;
        private System.Windows.Forms.Button Choose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox LbSelected;
        private System.Windows.Forms.Label label1;
    }
}

