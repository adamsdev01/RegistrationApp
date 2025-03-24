using RegistrationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationApp.Services
{
	public class AccountService
	{
		public static string RegisterNewAppUser(RegisterViewModel viewModel)
		{
			using (var dbContext = new UserRegistrationDBEntities())
			{
				//create RegisteredUser table in RegistrationDB
				// when a new account is created, a new user is added
				// to the application as well
				//RegisteredUser user = new RegisteredUser
				//{
				//	UserAccountId = Guid.NewGuid(),
				//};
				//dbContext.RegisteredUsers.Add(user);
				//dbContext.SaveChanges();

				//string userId = user.UserAccountId.ToString();

				//return userId;
				return null;
			}
		}
	}
}