namespace CustomerDataEntry
{
    partial class dataForm
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
            this.dataList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // dataList
            // 
            this.dataList.HideSelection = false;
            this.dataList.Location = new System.Drawing.Point(21, 24);
            this.dataList.Name = "dataList";
            this.dataList.Size = new System.Drawing.Size(425, 182);
            this.dataList.TabIndex = 0;
            this.dataList.UseCompatibleStateImageBehavior = false;
            // 
            // dataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 233);
            this.Controls.Add(this.dataList);
            this.Name = "dataForm";
            this.Text = "Submitted Data";
            this.Load += new System.EventHandler(this.dataForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView dataList;
    }
}