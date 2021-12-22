
namespace CourseWork
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
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDirection = new System.Windows.Forms.TrackBar();
            this.lblDirection = new System.Windows.Forms.Label();
            this.tbSpreading = new System.Windows.Forms.TrackBar();
            this.lblSpreading = new System.Windows.Forms.Label();
            this.tbGraviton = new System.Windows.Forms.TrackBar();
            this.tbGraviton2 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPortalSize = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpreading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPortalSize)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(-2, 0);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(1503, 932);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseClick);
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1415, 982);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 22);
            this.button1.TabIndex = 1;
            this.button1.Text = "вкл/выкл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(1412, 961);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "сила тяжести";
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(314, 977);
            this.tbDirection.Maximum = 359;
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(297, 45);
            this.tbDirection.TabIndex = 3;
            this.tbDirection.Scroll += new System.EventHandler(this.tbDirection_Scroll);
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDirection.Location = new System.Drawing.Point(617, 987);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(0, 13);
            this.lblDirection.TabIndex = 4;
            // 
            // tbSpreading
            // 
            this.tbSpreading.LargeChange = 0;
            this.tbSpreading.Location = new System.Drawing.Point(12, 977);
            this.tbSpreading.Maximum = 180;
            this.tbSpreading.Name = "tbSpreading";
            this.tbSpreading.Size = new System.Drawing.Size(265, 45);
            this.tbSpreading.TabIndex = 5;
            this.tbSpreading.Scroll += new System.EventHandler(this.tbSpreading_Scroll);
            // 
            // lblSpreading
            // 
            this.lblSpreading.AutoSize = true;
            this.lblSpreading.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSpreading.Location = new System.Drawing.Point(283, 987);
            this.lblSpreading.Name = "lblSpreading";
            this.lblSpreading.Size = new System.Drawing.Size(0, 13);
            this.lblSpreading.TabIndex = 6;
            // 
            // tbGraviton
            // 
            this.tbGraviton.LargeChange = 0;
            this.tbGraviton.Location = new System.Drawing.Point(1030, 977);
            this.tbGraviton.Maximum = 500;
            this.tbGraviton.Name = "tbGraviton";
            this.tbGraviton.Size = new System.Drawing.Size(185, 45);
            this.tbGraviton.TabIndex = 7;
            this.tbGraviton.Scroll += new System.EventHandler(this.tbGravion_Scroll);
            // 
            // tbGraviton2
            // 
            this.tbGraviton2.LargeChange = 0;
            this.tbGraviton2.Location = new System.Drawing.Point(1221, 977);
            this.tbGraviton2.Maximum = 500;
            this.tbGraviton2.Name = "tbGraviton2";
            this.tbGraviton2.Size = new System.Drawing.Size(185, 45);
            this.tbGraviton2.TabIndex = 8;
            this.tbGraviton2.Scroll += new System.EventHandler(this.tbGraviton2_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 955);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(106, 961);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "разброс частиц";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(1244, 961);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "сила гравитона на экране";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(384, 961);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "начальное направление частиц";
            // 
            // tbPortalSize
            // 
            this.tbPortalSize.LargeChange = 0;
            this.tbPortalSize.Location = new System.Drawing.Point(645, 977);
            this.tbPortalSize.Maximum = 300;
            this.tbPortalSize.Name = "tbPortalSize";
            this.tbPortalSize.Size = new System.Drawing.Size(185, 45);
            this.tbPortalSize.TabIndex = 14;
            this.tbPortalSize.Scroll += new System.EventHandler(this.tbPortalSize_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(695, 961);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "размер порталов";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(1037, 961);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "сила антигравитона на курсоре";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(879, 982);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 22);
            this.button2.TabIndex = 17;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(858, 961);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "выбрать цвет портала";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1500, 1034);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPortalSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbGraviton2);
            this.Controls.Add(this.tbGraviton);
            this.Controls.Add(this.lblSpreading);
            this.Controls.Add(this.tbSpreading);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.tbDirection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpreading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPortalSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbDirection;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.TrackBar tbSpreading;
        private System.Windows.Forms.Label lblSpreading;
        private System.Windows.Forms.TrackBar tbGraviton;
        private System.Windows.Forms.TrackBar tbGraviton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar tbPortalSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
    }
}

