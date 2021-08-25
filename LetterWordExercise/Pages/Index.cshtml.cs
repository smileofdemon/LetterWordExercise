using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using LetterWordExercise.Services.Interfaces;

namespace LetterWordExercise.Pages
{
    public class IndexModel : PageModel
    {
        private const string OUTPUT_FILE_NAME = "output.txt";
        private readonly IMatchWordsService _matchWordsService;

        public IndexModel(IMatchWordsService matchWordsService)
        {
            _matchWordsService = matchWordsService;
        }

        public async Task<FileResult> OnPostMatchFileAsync(IFormFile uploadedFile, int count)
        {
            if (uploadedFile == null)
                return null;

            Encoding encoder;
            using (var reader = new StreamReader(uploadedFile.OpenReadStream()))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        _matchWordsService.AddWord(line);
                    }
                }
                encoder = reader.CurrentEncoding;
            }

            var output = _matchWordsService.GetMatchWords(count);
            byte[] fileBytes = encoder.GetBytes(output);

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Text.RichText, OUTPUT_FILE_NAME);
        }
    }
}
