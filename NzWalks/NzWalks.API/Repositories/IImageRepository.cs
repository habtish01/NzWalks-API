﻿using NzWalks.API.Models.Domain;

namespace NzWalks.API.Repositories
{
    public interface IImageRepository
    {
        Task<Image> UploadImage(Image image);   
    }
}
