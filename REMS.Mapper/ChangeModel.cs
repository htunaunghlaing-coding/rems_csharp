﻿using REMS.Models.Appointment;

namespace REMS.Mapper;

public static class ChangeModel
{
    #region Agent

    public static User ChangeUser(this AgentRequestModel requestModel)
    {
        User user = new User
        {
            Name = requestModel.AgentName!,
            Email = requestModel.Email!,
            Password = requestModel.Password!,
            Phone = requestModel.Phone,
            Role = "Agent",
            DateCreated = requestModel.DateCreate
        };
        return user;
    }

    public static Agent ChangeAgent(this AgentRequestModel requestModel)
    {
        Agent agent = new Agent
        {
            UserId = requestModel.UserId,
            AgencyName = requestModel.AgentName!,
            LicenseNumber = requestModel.LicenseNumber!,
            Phone = requestModel.Phone!,
            Email = requestModel.Email!,
            Address = requestModel.Address!
        };
        return agent;
    }

    #endregion

    #region Client
    public static User ChangeUser(this ClientRequestModel requestModel)
    {
        string firstName = requestModel.FirstName ?? string.Empty;
        string lastName = requestModel.LastName ?? string.Empty;
        string Name = string.Concat(firstName, (!string.IsNullOrEmpty(firstName) ? " " : string.Empty), lastName);
        User user = new User
        {
            Name = Name,
            Email = requestModel.Email!,
            Password = requestModel.Password!,
            Phone = requestModel.Phone,
            Role = "Client",
            DateCreated = requestModel.DateCreate
        };
        return user;
    }

    public static Client Change(this ClientRequestModel requestModel)
    {
        Client client = new Client
        {
            UserId = requestModel.UserId,
            AgentId = requestModel.AgentId,
            FirstName = requestModel.FirstName,
            LastName = requestModel.LastName,
            Phone = requestModel.Phone,
            Email = requestModel.Email,
            Address = requestModel.Address,
        };
        return client;
    }

    public static ClientResponseModel Change(this Client dataModel)
    {
        var clientResponseModel = new ClientResponseModel
        {
            ClientId = dataModel.ClientId,
            UserId = dataModel.UserId,
            AgentId = dataModel.AgentId,
            FirstName = dataModel.FirstName,
            LastName = dataModel.LastName,
            Phone = dataModel.Phone,
            Email = dataModel.Email,
            Address = dataModel.Address,
        };
        return clientResponseModel;
    }
    #endregion

    #region Property

    public static PropertyModel Change(this Property dataModel)
    {
        var propertyModel = new PropertyModel()
        {
            PropertyId = dataModel.PropertyId,
            Address = dataModel.Address,
            City = dataModel.City,
            State = dataModel.State,
            ZipCode = dataModel.ZipCode,
            PropertyType = dataModel.PropertyType,
            Price = dataModel.Price,
            Size = dataModel.Size,
            NumberOfBedrooms = dataModel.NumberOfBedrooms,
            NumberOfBathrooms = dataModel.NumberOfBathrooms,
            YearBuilt = dataModel.YearBuilt,
            Description = dataModel.Description,
            Status = dataModel.Status,
            DateListed = dataModel.DateListed
        };

        return propertyModel;
    }

    public static Property Change(this PropertyRequestModel requestModel)
    {
        Property property = new Property
        {
            PropertyId = requestModel.PropertyId ?? 0,
            Address = requestModel.Address,
            City = requestModel.City,
            State = requestModel.State,
            ZipCode = requestModel.ZipCode,
            PropertyType = requestModel.PropertyType,
            Price = requestModel.Price,
            Size = requestModel.Size,
            NumberOfBedrooms = requestModel.NumberOfBedrooms,
            NumberOfBathrooms = requestModel.NumberOfBathrooms,
            YearBuilt = requestModel.YearBuilt,
            Description = requestModel.Description,
            Status = requestModel.Status,
            DateListed = requestModel.DateListed
        };
        return property;
    }

    //public static PropertyResponseModel ChangeToResponseModel(this Property dataModel, List<PropertyImage> images)
    //{
    //    var propertyResponseModel = new PropertyResponseModel
    //    {
    //        Property = new PropertyModel
    //        {
    //            PropertyId = dataModel.PropertyId,
    //            Address = dataModel.Address,
    //            City = dataModel.City,
    //            State = dataModel.State,
    //            ZipCode = dataModel.ZipCode,
    //            PropertyType = dataModel.PropertyType,
    //            Price = dataModel.Price,
    //            Size = dataModel.Size,
    //            NumberOfBedrooms = dataModel.NumberOfBedrooms,
    //            NumberOfBathrooms = dataModel.NumberOfBathrooms,
    //            YearBuilt = dataModel.YearBuilt,
    //            Description = dataModel.Description,
    //            Status = dataModel.Status,
    //            DateListed = dataModel.DateListed
    //        },
    //        Images = images.Select(img => new PropertyImageModel
    //        {
    //            ImageId = img.ImageId,
    //            PropertyId = img.PropertyId,
    //            ImageUrl = img.ImageUrl,
    //            Description = img.Description,
    //            DateUploaded = img.DateUploaded
    //        }).ToList()
    //    };

    //    return propertyResponseModel;
    //}

    #endregion

    #region Property Image

    public static PropertyImageModel Change(this PropertyImage dataModel)
    {
        var propertyModel = new PropertyImageModel()
        {
            ImageId = dataModel.ImageId,
            PropertyId = dataModel.PropertyId,
            ImageUrl = dataModel.ImageUrl,
            Description = dataModel.Description,
            DateUploaded = dataModel.DateUploaded
        };

        return propertyModel;
    }

    #endregion

    #region Review

    public static ReviewModel Change(this Review dataModel)
    {
        var reviewModel = new ReviewModel()
        {
            ReviewId = dataModel.ReviewId,
            UserId = dataModel.UserId,
            PropertyId = dataModel.PropertyId,
            Rating = dataModel.Rating,
            Comments = dataModel.Comments,
            DateCreated = dataModel.DateCreated
        };

        return reviewModel;
    }

    public static Review Change(this ReviewModel dataModel)
    {
        var review = new Review()
        {
            ReviewId = dataModel.ReviewId,
            UserId = dataModel.UserId,
            PropertyId = dataModel.PropertyId,
            Rating = dataModel.Rating,
            Comments = dataModel.Comments,
            DateCreated = dataModel.DateCreated
        };

        return review;
    }

    #endregion

    #region Appointment

    public static Appointment ChangeAppointment(this AppointmentRequestModel requestModel)
    {
        Appointment appointment = new Appointment
        {
            AgentId = requestModel.AgentId,
            ClientId = requestModel.ClientId,
            PropertyId = requestModel.PropertyId,
            AppointmentDate = requestModel.AppointmentDate,
            AppointmentTime = TimeSpan.Parse(requestModel.AppointmentTime!),
            Status = requestModel.Status,
            Notes = requestModel.Notes
        };
        return appointment;
    }

    #endregion


}