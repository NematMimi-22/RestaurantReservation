﻿using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.IRepositories;
using RestaurantReservation.Repositories;
using Microsoft.EntityFrameworkCore;
public class RestaurantRepository : EntityRepositoryBase<Restaurant, int>, IRestaurantRepository
{
    public RestaurantRepository(DbContext dbContext) : base(dbContext)
    {
    }
}