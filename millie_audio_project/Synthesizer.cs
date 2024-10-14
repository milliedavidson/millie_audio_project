using System.Media;

namespace millie_audio_project
{
    /* This is a partial class so code can be added to the class without having to recreate the source file that
    includes automatically generated source */
    public partial class Synthesizer : Form
    {
        private const int SampleRate = 41000;

        /* Using short because it represents a 16-bit signed integer, which is needed for a sample rate of 16 bits.
        A short can hold a max value of 32,767 and once this value is reached, it will decrement in value until
        it reaches the minimum value of -32,768. Then it will go back up again */
        private const short BitsPerSample = 16;

        public Synthesizer()
        {
            InitializeComponent();
        }

        private void Synthesizer_Load(object sender, EventArgs e)
        {
        }

        //Takes keyboard input (this is enabled via the Form: Properties > Misc > Key Preview > True)
        private void Synthesizer_KeyDown(object sender, KeyEventArgs e)
        {
            short[] wave = new short[SampleRate];
            /* wave is an array of short values but binaryWriter only accepts byte values. Need to split each short
            into 2 bytes because a short is double the length of a byte. 1 BYTE = 8 BITS. 1 SHORT = 16 BITS */

            byte[] binaryWave = new byte[SampleRate * sizeof(short)]; /* short because it's the data type of wave and
            we want 2 lots of 8 bits to create this byte array. We could just put 2 here but, using sizeof makes
            our intent clearer */
            
            float frequency = 440f;

            // i is the unit of time for each sample in SampleRate. TODO: Why 'i' for time? Isn't 't' or 'time' clearer?
            for (int i = 0; i < SampleRate; i++)
            {
                /* Algorithm from: https://www.youtube.com/watch?v=fp1Snqq9ovw. This algorithm generates the sine wave
                (and is why the short values go up and down, like a WAVE). TODO: Could make this a method or function */
                wave[i] = Convert.ToInt16(short.MaxValue * Math.Sin(((Math.PI * 2 * frequency) / SampleRate) * i));
            }

            /* Check the parameters required for the method below. Offset is 0, so it starts at the start. Splits every
            short into 2 bytes and writes them into binaryWave. BlockCopy is resizing the data */
            Buffer.BlockCopy(wave, 0, binaryWave, 0, wave.Length * sizeof(short));

            /* To play the samples generated in the for loop, they have to be passed to software that will handle the
            digital to analogue conversion. The class below is a STREAM which will contain all the samples and some
            settings. This is because the sampler needs to know what sample rate to play the sample at etc. Wave file
            format config: http://soundfile.sapp.org/doc/WaveFormat/ - this is what we put into the stream */

            /* MemoryStream contains all the chunk information from the link above. Everything we write into MemoryStream
            with BinaryWriter comes from the requirements in the link above. using statement is here to help with resource
            management - frees up the connection with the file/object (not having this can cause memory leaks). 
            TODO: Look up the code for Stream */
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
            {
                // The Wave file format specifies what these variables need
                short blockAlign = BitsPerSample / 8;
                int subChunkTwoSize = SampleRate * blockAlign;

                // RIFF needs to be individual characters so BinaryWriter can understand it
                binaryWriter.Write(new[] { 'R', 'I', 'F', 'F' });
                binaryWriter.Write(36 + subChunkTwoSize); // This comes from ChunkSize
                binaryWriter.Write(new[] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });
                binaryWriter.Write(16); // For PCM, because that's all we're working with

                /* NOTE: the size in the requirements - 4 refers to RIFF (4 bytes, 1 byte per character), whereas 2 is
                2 bytes because 16 bits = 2 bytes and a 16 bit integer = the SHORT data type. Which is why we have
                to cast 1 to a short below, so it only writes 2 bytes, instead of 4 */
                binaryWriter.Write((short)1);
                binaryWriter.Write((short)1); // number of channels
                binaryWriter.Write(SampleRate);
                binaryWriter.Write(SampleRate * blockAlign);
                binaryWriter.Write(blockAlign);
                binaryWriter.Write(BitsPerSample);
                binaryWriter.Write(new[] { 'd', 'a', 't', 'a' });
                binaryWriter.Write(subChunkTwoSize);

                /* Now we have the stream of data, the SoundPlayer class can accept it. memoryStream has a position
                (like a pointer) which is why we set the position below. 0 takes us to the start (to RIFF) */
                memoryStream.Position = 0;
                new SoundPlayer(memoryStream).Play();
            }
        }
    }
}
