using API.ViewModels;

namespace API.Services
{
    public interface IAlgorithmsService
    {
        string GetPattern(string phrase);
        string BuildFace(FaceParametersInput parameters);
    }
}
