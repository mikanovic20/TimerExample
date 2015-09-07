namespace TimerUsers
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rtb6 = new System.Windows.Forms.RichTextBox();
            this.rtb5 = new System.Windows.Forms.RichTextBox();
            this.rtb8 = new System.Windows.Forms.RichTextBox();
            this.rtb7 = new System.Windows.Forms.RichTextBox();
            this.rtb4 = new System.Windows.Forms.RichTextBox();
            this.rtb1 = new System.Windows.Forms.RichTextBox();
            this.rtb2 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rtb3 = new System.Windows.Forms.RichTextBox();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.rtb6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rtb5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rtb8, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rtb7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rtb4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.rtb1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.rtb2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rtb3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nudInterval, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(715, 298);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // rtb6
            // 
            this.rtb6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.rtb6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb6.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rtb6.Location = new System.Drawing.Point(181, 172);
            this.rtb6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb6.Name = "rtb6";
            this.rtb6.Size = new System.Drawing.Size(172, 122);
            this.rtb6.TabIndex = 8;
            this.rtb6.Text = "";
            // 
            // rtb5
            // 
            this.rtb5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.rtb5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rtb5.Location = new System.Drawing.Point(3, 172);
            this.rtb5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb5.Name = "rtb5";
            this.rtb5.Size = new System.Drawing.Size(172, 122);
            this.rtb5.TabIndex = 7;
            this.rtb5.Text = "";
            // 
            // rtb8
            // 
            this.rtb8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.rtb8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb8.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rtb8.Location = new System.Drawing.Point(537, 172);
            this.rtb8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb8.Name = "rtb8";
            this.rtb8.Size = new System.Drawing.Size(175, 122);
            this.rtb8.TabIndex = 6;
            this.rtb8.Text = "";
            // 
            // rtb7
            // 
            this.rtb7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.rtb7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb7.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rtb7.Location = new System.Drawing.Point(359, 172);
            this.rtb7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb7.Name = "rtb7";
            this.rtb7.Size = new System.Drawing.Size(172, 122);
            this.rtb7.TabIndex = 5;
            this.rtb7.Text = "";
            // 
            // rtb4
            // 
            this.rtb4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.rtb4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rtb4.Location = new System.Drawing.Point(537, 42);
            this.rtb4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb4.Name = "rtb4";
            this.rtb4.Size = new System.Drawing.Size(175, 122);
            this.rtb4.TabIndex = 3;
            this.rtb4.Text = "";
            // 
            // rtb1
            // 
            this.rtb1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.rtb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rtb1.Location = new System.Drawing.Point(3, 42);
            this.rtb1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb1.Name = "rtb1";
            this.rtb1.Size = new System.Drawing.Size(172, 122);
            this.rtb1.TabIndex = 4;
            this.rtb1.Text = "";
            // 
            // rtb2
            // 
            this.rtb2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.rtb2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rtb2.Location = new System.Drawing.Point(181, 42);
            this.rtb2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb2.Name = "rtb2";
            this.rtb2.Size = new System.Drawing.Size(172, 122);
            this.rtb2.TabIndex = 2;
            this.rtb2.Text = "";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(3, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtb3
            // 
            this.rtb3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.rtb3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rtb3.Location = new System.Drawing.Point(359, 42);
            this.rtb3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb3.Name = "rtb3";
            this.rtb3.Size = new System.Drawing.Size(172, 122);
            this.rtb3.TabIndex = 1;
            this.rtb3.Text = "";
            // 
            // nudInterval
            // 
            this.nudInterval.Dock = System.Windows.Forms.DockStyle.Left;
            this.nudInterval.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nudInterval.Location = new System.Drawing.Point(181, 8);
            this.nudInterval.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.nudInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudInterval.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(172, 23);
            this.nudInterval.TabIndex = 9;
            this.nudInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudInterval.ValueChanged += new System.EventHandler(this.nudInterval_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 298);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox rtb6;
        private System.Windows.Forms.RichTextBox rtb5;
        private System.Windows.Forms.RichTextBox rtb8;
        private System.Windows.Forms.RichTextBox rtb7;
        private System.Windows.Forms.RichTextBox rtb4;
        private System.Windows.Forms.RichTextBox rtb1;
        private System.Windows.Forms.RichTextBox rtb2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtb3;
        private System.Windows.Forms.NumericUpDown nudInterval;
    }
}

