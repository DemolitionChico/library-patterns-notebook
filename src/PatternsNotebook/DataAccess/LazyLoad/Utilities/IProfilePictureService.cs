namespace PatternsNotebook.DataAccess.LazyLoad.Utilities;

internal interface IProfilePictureService
{
    byte[] GetFor(string userId);
}