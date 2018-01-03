using System.Drawing;
using System.Windows.Forms;

namespace windowHelper
{
    partial class WindowHelper
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowHelper));
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.DateLabel = new System.Windows.Forms.Label();
            this.WeekLabel = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.weatherButten = new System.Windows.Forms.Button();
            this.weatherLabel = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.TimeLabel.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.TimeLabel.Font = new System.Drawing.Font("宋体", 50.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TimeLabel.ForeColor = System.Drawing.Color.White;
            this.TimeLabel.Location = new System.Drawing.Point(23, 48);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(286, 118);
            this.TimeLabel.TabIndex = 0;
            this.TimeLabel.Text = "时钟";
            this.TimeLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TimeLabel_MouseDown);
            this.TimeLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TimeLabel_MouseMove);
            this.TimeLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TimeLabel_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateLabel.ForeColor = System.Drawing.Color.White;
            this.DateLabel.Location = new System.Drawing.Point(62, 179);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(68, 28);
            this.DateLabel.TabIndex = 1;
            this.DateLabel.Text = "日期";
            // 
            // WeekLabel
            // 
            this.WeekLabel.AutoSize = true;
            this.WeekLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WeekLabel.ForeColor = System.Drawing.Color.White;
            this.WeekLabel.Location = new System.Drawing.Point(218, 179);
            this.WeekLabel.Name = "WeekLabel";
            this.WeekLabel.Size = new System.Drawing.Size(68, 28);
            this.WeekLabel.TabIndex = 2;
            this.WeekLabel.Text = "星期";
            // 
            // btn_close
            // 
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("等线 Light", 15.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(301, 2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(58, 58);
            this.btn_close.TabIndex = 3;
            this.btn_close.Text = "x";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // weatherButten
            // 
            this.weatherButten.BackColor = System.Drawing.SystemColors.Control;
            this.weatherButten.Cursor = System.Windows.Forms.Cursors.Hand;
            this.weatherButten.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.weatherButten.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.weatherButten.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.weatherButten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.weatherButten.ForeColor = System.Drawing.Color.White;
            this.weatherButten.Image = ((System.Drawing.Image)(resources.GetObject("weatherButten.Image")));
            this.weatherButten.Location = new System.Drawing.Point(67, 210);
            this.weatherButten.Name = "weatherButten";
            this.weatherButten.Size = new System.Drawing.Size(97, 80);
            this.weatherButten.TabIndex = 4;
            this.weatherButten.UseVisualStyleBackColor = false;
            this.weatherButten.Click += new System.EventHandler(this.weatherButten_Click);
            this.weatherButten.MouseLeave += new System.EventHandler(this.weatherButter_MouseLeave);
            this.weatherButten.MouseHover += new System.EventHandler(this.weatherButter_MouseHover);
            // 
            // weatherLabel
            // 
            this.weatherLabel.AutoSize = true;
            this.weatherLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.weatherLabel.ForeColor = System.Drawing.Color.White;
            this.weatherLabel.Location = new System.Drawing.Point(175, 234);
            this.weatherLabel.Name = "weatherLabel";
            this.weatherLabel.Size = new System.Drawing.Size(68, 28);
            this.weatherLabel.TabIndex = 5;
            this.weatherLabel.Text = "天气";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 600000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // WindowHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(360, 285);
            this.Controls.Add(this.weatherLabel);
            this.Controls.Add(this.weatherButten);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.WeekLabel);
            this.Controls.Add(this.DateLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowHelper";
            this.Text = "WindowsHelper";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.WindowHelper_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label WeekLabel;
        private System.Windows.Forms.Button btn_close;
        private Button weatherButten;
        private Label weatherLabel;
        private Timer timer2;
    }
}