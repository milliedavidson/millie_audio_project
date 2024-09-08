using System.Windows.Forms;
using System.Media;

namespace millie_audio_project
{
    // This is a partial class so code can be added to the class without having to recreate the source file that
    // includes automatically generated source
    public partial class Synthesizer : Form
    {
        private const int SampleRate = 41000;

        // Using short because it represents a 16-bit signed integer, which is needed for a sample rate of 16 bits
        // A short can hold a max value of 32,767 and once this value is reached, it will decrement in value until 
        // it reaches the minimum value of -32,768. Then it will go back up again.
        private const short BitsPerSample = 16;

        public Synthesizer()
        {
            InitializeComponent();
        }

        private void Synthesizer_Load(object sender, EventArgs e)
        {
        }

        // Takes keyboard input (this is enabled via the Form: Properties > Misc > Key Preview > True)
        private void Synthesizer_KeyDown(object sender, KeyEventArgs e)
        {
            short[] wave = new short[SampleRate];
            float frequency = 440f;

            // i is the unit of time for each sample in SampleRate
            for (int i = 0; i < SampleRate; i++)
            {
                // Algorithm from: https://www.youtube.com/watch?v=fp1Snqq9ovw
                // This algorithm generates the sine wave (and is why the short values goes up and down like a WAVE)
                wave[i] = Convert.ToInt16(short.MaxValue * Math.Sin(((Math.PI * 2 * frequency) / SampleRate) * i));
            }

            // To play the samples generated above, they have to be passed to software that will handle the
            // digital to analogue conversion.The class below is a STREAM which will contain all the samples
            // and some settings. This is because the sampler needs to know what sample rate to play the sample at etc.
            // Wave file format config: http://soundfile.sapp.org/doc/WaveFormat/ - this is what we put into the stream

            // MemoryStream contains all the chunk information from the link above
            using (MemoryStream memoryStream = new) 
            using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
        }
    }
}
