namespace millie_audio_project
{
    // Oscillator inherits all functionality from GroupBox
    public class Oscillator : GroupBox
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

            // Repeat the above for each button. TODO: Create an extension method for this e.g. addButton
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

        public WaveForm WaveForm { get; set; }

        /* EventHandler delegate (see more details in the README). Handles events for the 'click' event on any of
        the wave buttons. Will also handle an event that has no event data. The naming convention for a click event is 
        to have the underscore (I think). 'sender' is the source of the event and 'e' is an object that contains no 
        event data. TODO: Organise this by moving to another file/folder? */
        private void WaveButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // cast the sender to a button so we don't have to do this throughout
        }
    }
}
