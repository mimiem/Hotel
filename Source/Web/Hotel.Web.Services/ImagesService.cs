namespace Hotel.Services
{
    using System.Collections.Generic;
    using Data.Models;
    using System.Linq;
    using Data.Models.Enumerations;
    using System;
    using CameraBazaar.Data.Common.Repository;
    using Web.Hotel.Web.ViewModels.Images;
    using Web.Infrastructure.Mapping;

    public class ImagesService
    {
        public IEnumerable<PictureViewModel> GetPictures(IRepository<Picture> pictures, string category)
        {
            ImageCategory enumCategory = (ImageCategory)0;

            if (Enum.IsDefined(typeof(ImageCategory), category))
            {
                enumCategory = (ImageCategory)Enum.Parse(typeof(ImageCategory), category);
            }
            IEnumerable<PictureViewModel> hotelPictures = pictures
                                    .All()
                                    .Where(p => p.Category == enumCategory)
                                    .To<PictureViewModel>()
                                    .ToList();

            return hotelPictures;
        }
    }
}
