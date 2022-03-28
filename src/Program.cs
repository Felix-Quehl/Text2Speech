using System.Globalization;
using System.IO;
using System.Speech.Synthesis;

namespace Text2Speech
{
    class Program
    {
        static void Main(string[] args)
        {
            var cultureArg = args[0];
            var voiceName = args[1];
            var inputFilePath = args[2];
            var outputFilePath = args[3];

            var text = File.ReadAllText(inputFilePath);

            var synthesizer = new SpeechSynthesizer();
            synthesizer.SetOutputToDefaultAudioDevice();
            synthesizer.SelectVoice(voiceName);
            var builder = new PromptBuilder();
            var culture = new CultureInfo(cultureArg);
            builder.StartVoice(culture);
            builder.AppendText(text);
            builder.EndVoice();

            synthesizer.SetOutputToWaveFile(outputFilePath);
            synthesizer.Speak(builder);
        }
    }
}
