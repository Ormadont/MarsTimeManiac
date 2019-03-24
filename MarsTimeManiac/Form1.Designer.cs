namespace MarsTimeManiac
{
    partial class Form1
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
            this.label_TodayTime = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label_YesterdayTime = new System.Windows.Forms.Label();
            this.label_monthTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_TodayTime
            // 
            this.label_TodayTime.AutoSize = true;
            this.label_TodayTime.Location = new System.Drawing.Point(10, 19);
            this.label_TodayTime.Name = "label_TodayTime";
            this.label_TodayTime.Size = new System.Drawing.Size(243, 13);
            this.label_TodayTime.TabIndex = 0;
            this.label_TodayTime.Text = "Сегодня компьютер начал работать --ч. назад.";
            // 
            // label_YesterdayTime
            // 
            this.label_YesterdayTime.AutoSize = true;
            this.label_YesterdayTime.Location = new System.Drawing.Point(10, 46);
            this.label_YesterdayTime.Name = "label_YesterdayTime";
            this.label_YesterdayTime.Size = new System.Drawing.Size(236, 13);
            this.label_YesterdayTime.TabIndex = 1;
            this.label_YesterdayTime.Text = "Вчерашний интервал работы компьютера --ч.";
            // 
            // label_monthTime
            // 
            this.label_monthTime.AutoSize = true;
            this.label_monthTime.Location = new System.Drawing.Point(10, 72);
            this.label_monthTime.Name = "label_monthTime";
            this.label_monthTime.Size = new System.Drawing.Size(242, 13);
            this.label_monthTime.TabIndex = 2;
            this.label_monthTime.Text = "Время с начала месяца до сегодняшнего дня ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_monthTime);
            this.Controls.Add(this.label_YesterdayTime);
            this.Controls.Add(this.label_TodayTime);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_TodayTime;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label_YesterdayTime;
        private System.Windows.Forms.Label label_monthTime;
    }
}

