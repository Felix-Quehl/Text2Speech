using System.Globalization;
using System.IO;
using System.Speech.Synthesis;

namespace Text2Speech
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFilePath = args[0];
            var outputFilePath = args[1];

            var text = File.ReadAllText(inputFilePath);

            var synthesizer = new SpeechSynthesizer();
            synthesizer.SetOutputToDefaultAudioDevice();
            var builder = new PromptBuilder();
            var culture = new CultureInfo("en-US");
            builder.StartVoice(culture);
            builder.AppendText(text);
            builder.EndVoice();

            synthesizer.SetOutputToWaveFile(outputFilePath);
            synthesizer.Speak(builder);
        }
    }
}
