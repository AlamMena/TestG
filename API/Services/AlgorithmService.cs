using API.ViewModels;

namespace API.Services
{
    public class AlgorithmService : IAlgorithmsService
    {

        public string BuildFace(FaceParametersInput faceParameters)
        {
            var result = $@"
                 {faceParameters.Hair?.PadRight(5, faceParameters.Hair[0])}
                {faceParameters.Border} {faceParameters.Eyebrows} {faceParameters.Eyebrows} {faceParameters.Border}
                {faceParameters.Ears} {faceParameters.Eyes} {faceParameters.Eyes} {faceParameters.Ears}
                {faceParameters.Border}  {faceParameters.Nose}  {faceParameters.Border}
                {faceParameters.Border}  {faceParameters.Mouth}  {faceParameters.Border}
                {faceParameters.Border}  {faceParameters.Chin}  {faceParameters.Border}";
            Console.WriteLine(result);
            return result;
        }

      

        public string GetPattern(string phrase)
        {
            // looking for the middle of the array
            int middleIndex = phrase.Length / 2;
            // If it's a pair array, we just get the middle element; if not, we get the middle element and the one before it.
            var result = new string(phrase.Length % 2 == 0
                ? new[] { phrase[middleIndex - 1], phrase[middleIndex] }
                : new[] { phrase[middleIndex] });

            return result;
        }
    }
}
