namespace ProNatur_Biomarkt_GmbH
{
    partial class MainMenuScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuScreen));
            this.btnProdukte = new System.Windows.Forms.Button();
            this.btnRechnung = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProdukte
            // 
            this.btnProdukte.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProdukte.BackgroundImage")));
            this.btnProdukte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProdukte.ForeColor = System.Drawing.Color.White;
            this.btnProdukte.Location = new System.Drawing.Point(12, 12);
            this.btnProdukte.Name = "btnProdukte";
            this.btnProdukte.Size = new System.Drawing.Size(275, 125);
            this.btnProdukte.TabIndex = 0;
            this.btnProdukte.Text = "Produkte verwalten";
            this.btnProdukte.UseVisualStyleBackColor = true;
            // 
            // btnRechnung
            // 
            this.btnRechnung.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRechnung.BackgroundImage")));
            this.btnRechnung.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechnung.ForeColor = System.Drawing.Color.White;
            this.btnRechnung.Location = new System.Drawing.Point(309, 12);
            this.btnRechnung.Name = "btnRechnung";
            this.btnRechnung.Size = new System.Drawing.Size(275, 125);
            this.btnRechnung.TabIndex = 1;
            this.btnRechnung.Text = "Rechnung erstellen";
            this.btnRechnung.UseVisualStyleBackColor = true;
            // 
            // MainMenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(596, 151);
            this.Controls.Add(this.btnRechnung);
            this.Controls.Add(this.btnProdukte);
            this.Name = "MainMenuScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hauptmenü";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProdukte;
        private System.Windows.Forms.Button btnRechnung;
    }
}