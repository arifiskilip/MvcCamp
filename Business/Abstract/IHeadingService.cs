﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHeadingService : IRepositoryService<Heading>
    {
        int HowMonyCategoriesOfSoftware();
        string CategoryNameWithMostTitles();
        string NumberOfHeading();
        List<HeadingDetailDto> HeadingDetails();
        List<Heading> GetAllHeadingStatus(bool statu);
        List<Heading> GetAllHeadingByWriter(int id);

    }
}
