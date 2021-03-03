using System;
using System.Collections.Generic;

using pde_poc_sim.Storage;

namespace pde_poc_sim.Storage.Mocks
{
    public static class UnemploymentRegion
    {
        public readonly static List<EFModels.UnemploymentRegion> Seed = new List<EFModels.UnemploymentRegion>() {
            new EFModels.UnemploymentRegion() {
                Id = Guid.NewGuid(),
                Code = "01",
                Province = "NL",
                Name = "St. Johns",
                UnemploymentRate = 13.1,
                LastUpdated = DateTime.Now,
                BestWeeks = 14
            },
            new EFModels.UnemploymentRegion() {
                Id = Guid.NewGuid(),
                Code = "65",
                Province = "PEI",
                Name = "Charlottetown",
                UnemploymentRate = 13.1,
                LastUpdated = DateTime.Now,
                BestWeeks = 14
            },
            new EFModels.UnemploymentRegion() {
                Id = Guid.NewGuid(),
                Code = "66",
                Province = "PEI",
                Name = "Prince Edward Island",
                UnemploymentRate = 13.1,
                LastUpdated = DateTime.Now,
                BestWeeks = 14
            },
            new EFModels.UnemploymentRegion() {
                Id = Guid.NewGuid(),
                Code = "04",
                Province = "NS",
                Name = "Eastern Nova Scotia",
                UnemploymentRate = 13.1,
                LastUpdated = DateTime.Now,
                BestWeeks = 14
            },
            new EFModels.UnemploymentRegion() {
                Id = Guid.NewGuid(),
                Code = "05",
                Province = "NS",
                Name = "Western Nova Scotia",
                UnemploymentRate = 13.1,
                LastUpdated = DateTime.Now,
                BestWeeks = 14
            },
            new EFModels.UnemploymentRegion() {
                Id = Guid.NewGuid(),
                Code = "06",
                Province = "NS",
                Name = "Halifax",
                UnemploymentRate = 13.1,
                LastUpdated = DateTime.Now,
                BestWeeks = 14
            },
            new EFModels.UnemploymentRegion() {
                Id = Guid.NewGuid(),
                Code = "12",
                Province = "QC",
                Name = "Trois Rivieres",
                UnemploymentRate = 13.1,
                LastUpdated = DateTime.Now,
                BestWeeks = 15
            },
            new EFModels.UnemploymentRegion() {
                Id = Guid.NewGuid(),
                Code = "22",
                Province = "ON",
                Name = "Ottawa",
                UnemploymentRate = 13.1,
                LastUpdated = DateTime.Now,
                BestWeeks = 18
            },
            new EFModels.UnemploymentRegion() {
                Id = Guid.NewGuid(),
                Code = "23",
                Province = "ON",
                Name = "Eastern Ontario",
                UnemploymentRate = 13.1,
                LastUpdated = DateTime.Now,
                BestWeeks = 18
            },
            new EFModels.UnemploymentRegion() {
                Id = Guid.NewGuid(),
                Code = "24",
                Province = "ON",
                Name = "Kingston",
                UnemploymentRate = 13.1,
                LastUpdated = DateTime.Now,
                BestWeeks = 18
            },
            new EFModels.UnemploymentRegion() {
                Id = Guid.NewGuid(),
                Code = "39",
                Province = "MN",
                Name = "Winnipeg",
                UnemploymentRate = 13.1,
                LastUpdated = DateTime.Now,
                BestWeeks = 18
            },

            new EFModels.UnemploymentRegion() {
                Id = Guid.NewGuid(),
                Code = "42",
                Province = "SK",
                Name = "Regina",
                UnemploymentRate = 13.1,
                LastUpdated = DateTime.Now,
                BestWeeks = 14
            },
            new EFModels.UnemploymentRegion() {
                Id = Guid.NewGuid(),
                Code = "46",
                Province = "AB",
                Name = "Calgary",
                UnemploymentRate = 13.1,
                LastUpdated = DateTime.Now,
                BestWeeks = 14
            },
            new EFModels.UnemploymentRegion() {
                Id = Guid.NewGuid(),
                Code = "48",
                Province = "AB",
                Name = "Northern Alberta",
                UnemploymentRate = 13.1,
                LastUpdated = DateTime.Now,
                BestWeeks = 14
            },
            new EFModels.UnemploymentRegion() {
                Id = Guid.NewGuid(),
                Code = "51",
                Province = "BC",
                Name = "Abbotsford",
                UnemploymentRate = 13.1,
                LastUpdated = DateTime.Now,
                BestWeeks = 14
            },
            new EFModels.UnemploymentRegion() {
                Id = Guid.NewGuid(),
                Code = "53",
                Province = "BC",
                Name = "Victoria",
                UnemploymentRate = 13.1,
                LastUpdated = DateTime.Now,
                BestWeeks = 14
            },
        };

    }
}
