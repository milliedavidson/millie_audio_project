namespace millie_audio_project
{
    public class Oscillator : GroupBox // Oscillator inherits all functionality from GroupBox
    {
        public Oscillator()
        {
            // The 5 buttons we use to select the waveform we want the oscillator to generate
            this.Controls.Add(new Button() // TODO: have a look to see if I can add a group
            {
                // Assign properties to the button
                Name = "Sine",
                Location = new(50, 100), // This is the location of the button on the form
                Text = "Sine" // Same as the name
            });

            // Repeat the above for each button TODO: must be a sleeker way to do this?
            // Extension method (e..g addButton)
            this.Controls.Add(new Button()
            {
                Name = "Square",
                Location = new(50, 300),
                Text = "Square"
            });

            this.Controls.Add(new Button()
            {
                Name = "Saw",
                Location = new(300, 100),
                Text = "Saw"
            });

            this.Controls.Add(new Button()
            {
                Name = "Triangle",
                Location = new(300, 300),
                Text = "Triangle"
            });

            this.Controls.Add(new Button()
            {
                Name = "Noise",
                Location = new(550, 100),
                Text = "Noise"
            });

            // Loop over the controls above to add size and font consistently
            foreach (Control control in this.Controls)
            {
                control.Size = new Size(225, 100);
                control.Font = new Font("Microsoft Sans Serif", 8);
            }
        }

        private void WaveButtonClick(object sender, EventArgs e)
        {

        }
