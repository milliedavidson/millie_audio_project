namespace millie_audio_project
{
    partial class Synthesizer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            oscillator1 = new Oscillator();
            SuspendLayout();
            // 
            // oscillator1
            // 
            oscillator1.Location = new Point(267, 148);
            oscillator1.Name = "oscillator1";
            oscillator1.Size = new Size(1029, 498);
            oscillator1.TabIndex = 0;
            oscillator1.TabStop = false;
            oscillator1.WaveForm = WaveForm.Sine;
            oscillator1.Enter += oscillator1_Enter;
            // 
            // Synthesizer
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1729, 1017);
            Controls.Add(oscillator1);
            KeyPreview = true;
            Name = "Synthesizer";
            Text = "Synthesizer";
            Load += Synthesizer_Load;
            KeyDown += Synthesizer_KeyDown;
            ResumeLayout(false);
        }

        #endregion

        private Oscillator oscillator1;
    }
}
