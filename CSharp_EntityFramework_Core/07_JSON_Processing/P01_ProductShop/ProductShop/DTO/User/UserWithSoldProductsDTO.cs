﻿using Newtonsoft.Json;

namespace ProductShop.DTO.User
{
    public class UserWithSoldProductsDTO
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("soldProducts")]
        public UserSoldProductsDTO[] SoldProducts { get; set; }
    }
}
