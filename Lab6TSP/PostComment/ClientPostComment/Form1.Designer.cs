namespace ClientPostComment
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
            this.dgp = new System.Windows.Forms.DataGridView();
            this.dgc = new System.Windows.Forms.DataGridView();
            this.buttonAddPost = new System.Windows.Forms.Button();
            this.textBoxDesc = new System.Windows.Forms.TextBox();
            this.textBoxDomain = new System.Windows.Forms.TextBox();
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.buttonAddComment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgp
            // 
            this.dgp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgp.Location = new System.Drawing.Point(12, 12);
            this.dgp.Name = "dgp";
            this.dgp.Size = new System.Drawing.Size(485, 264);
            this.dgp.TabIndex = 0;
            // 
            // dgc
            // 
            this.dgc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgc.Location = new System.Drawing.Point(517, 12);
            this.dgc.Name = "dgc";
            this.dgc.Size = new System.Drawing.Size(475, 264);
            this.dgc.TabIndex = 1;
            // 
            // buttonAddPost
            // 
            this.buttonAddPost.Location = new System.Drawing.Point(16, 360);
            this.buttonAddPost.Name = "buttonAddPost";
            this.buttonAddPost.Size = new System.Drawing.Size(251, 23);
            this.buttonAddPost.TabIndex = 2;
            this.buttonAddPost.Text = "Add Post";
            this.buttonAddPost.UseVisualStyleBackColor = true;
            this.buttonAddPost.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxDesc
            // 
            this.textBoxDesc.Location = new System.Drawing.Point(87, 282);
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.Size = new System.Drawing.Size(180, 20);
            this.textBoxDesc.TabIndex = 3;
            // 
            // textBoxDomain
            // 
            this.textBoxDomain.Location = new System.Drawing.Point(87, 308);
            this.textBoxDomain.Name = "textBoxDomain";
            this.textBoxDomain.Size = new System.Drawing.Size(180, 20);
            this.textBoxDomain.TabIndex = 4;
            // 
            // textBoxDate
            // 
            this.textBoxDate.Location = new System.Drawing.Point(87, 334);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(180, 20);
            this.textBoxDate.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Domain:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(752, 337);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Comment:";
            // 
            // textBoxComment
            // 
            this.textBoxComment.Location = new System.Drawing.Point(812, 334);
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(180, 20);
            this.textBoxComment.TabIndex = 10;
            // 
            // buttonAddComment
            // 
            this.buttonAddComment.Location = new System.Drawing.Point(741, 360);
            this.buttonAddComment.Name = "buttonAddComment";
            this.buttonAddComment.Size = new System.Drawing.Size(251, 23);
            this.buttonAddComment.TabIndex = 11;
            this.buttonAddComment.Text = "Add Comment To Selected Post";
            this.buttonAddComment.UseVisualStyleBackColor = true;
            this.buttonAddComment.Click += new System.EventHandler(this.buttonAddComment_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 394);
            this.Controls.Add(this.buttonAddComment);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDate);
            this.Controls.Add(this.textBoxDomain);
            this.Controls.Add(this.textBoxDesc);
            this.Controls.Add(this.buttonAddPost);
            this.Controls.Add(this.dgc);
            this.Controls.Add(this.dgp);
            this.Name = "Form1";
            this.Text = "WCF & EF";
            ((System.ComponentModel.ISupportInitialize)(this.dgp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgp;
        private System.Windows.Forms.DataGridView dgc;
        private System.Windows.Forms.Button buttonAddPost;
        private System.Windows.Forms.TextBox textBoxDesc;
        private System.Windows.Forms.TextBox textBoxDomain;
        private System.Windows.Forms.TextBox textBoxDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Button buttonAddComment;
    }
}

