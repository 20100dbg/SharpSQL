namespace SharpSQL
{
    partial class InputDialog
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
            this.tb_input = new System.Windows.Forms.TextBox();
            this.b_ok = new System.Windows.Forms.Button();
            this.b_cancel = new System.Windows.Forms.Button();
            this.l_text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_input
            // 
            this.tb_input.Location = new System.Drawing.Point(12, 46);
            this.tb_input.Name = "tb_input";
            this.tb_input.Size = new System.Drawing.Size(266, 20);
            this.tb_input.TabIndex = 0;
            // 
            // b_ok
            // 
            this.b_ok.Location = new System.Drawing.Point(45, 83);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(75, 23);
            this.b_ok.TabIndex = 1;
            this.b_ok.Text = "OK";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // b_cancel
            // 
            this.b_cancel.Location = new System.Drawing.Point(172, 83);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(75, 23);
            this.b_cancel.TabIndex = 2;
            this.b_cancel.Text = "Annuler";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // l_text
            // 
            this.l_text.AutoSize = true;
            this.l_text.Location = new System.Drawing.Point(12, 9);
            this.l_text.Name = "l_text";
            this.l_text.Size = new System.Drawing.Size(0, 13);
            this.l_text.TabIndex = 3;
            // 
            // InputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 151);
            this.Controls.Add(this.l_text);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_ok);
            this.Controls.Add(this.tb_input);
            this.Name = "InputDialog";
            this.Text = "InputDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_input;
        private System.Windows.Forms.Button b_ok;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Label l_text;
    }
}