using System;
using System.Windows.Forms; // inherit from the groupBox control
using System.Drawing;

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
                Location = new(10, 15), // This is the location of the button on the form
                Text = "Sine" // Same as the name
            });

            // Repeat the above for each button TODO: must be a sleeker way to do this?
            // Extension method (e..g addButton)
            this.Controls.Add(new Button()
            {
                Name = "Square",
                Location = new(65, 15),
                Text = "Square"
            });

            this.Controls.Add(new Button()
            {
                Name = "Saw",
                Location = new(120, 15),
                Text = "Saw"
            });

            this.Controls.Add(new Button()
            {
                Name = "Triangle",
                Location = new(10, 50),
                Text = "Triangle"
            });

            this.Controls.Add(new Button()
            {
                Name = "Noise",
                Location = new(65, 50),
                Text = "Noise"
            });
        }
    }
}
