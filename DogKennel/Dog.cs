class Dog {
    public Guid ID = Guid.NewGuid();
    public string Name { get; }
    public string? Description { get; }
    public int Stamina { get; }
    public string Breed { get; }
    public int Gender { get; }
    public int Size { get; }
    public int Chonk { get;  }

    /// <summary>
    /// Create a dog
    /// </summary>
    /// <param name="name">Name of the dog</param>
    /// <param name="description">A short personal Description of the dog</param>
    /// <param name="stamina">How much the dog can handle</param>
    /// <param name="breed">The breed of the dog</param>
    /// <param name="gender">Gender of the dog 0 for male 1 for female</param>
    /// <param name="size">Size of the dog: 1 for small, 2 for medium, 3 for large, 4 for extra large</param>
    /// <param name="chonk">Body fat percentage: 1 for 20%, 2 for 30%, 3 for 40%, 4 for 50%, 5 for 60%, 6 for 70%. For refereance see <a href="https://www.pahoaanimalhospital.com/uploads/1/3/2/6/132610786/chonk_orig.jpg">Chonk chart</a></param>
    public Dog(string name, string? description, int stamina, string breed, int gender, int size, int chonk) {
        if (name == null || name == "") throw new ArgumentNullException("name");
        if (stamina <= 0) throw new ArgumentNullException("stamina");
        if (breed == null || breed == "") throw new ArgumentNullException("breed");
        if (gender != 0 && gender != 1) throw new ArgumentOutOfRangeException("gender");
        if (size <= 0) throw new ArgumentOutOfRangeException("size");
        if (chonk > 6) throw new ArgumentOutOfRangeException("chonk");
        
        Name = name; 
        Description = description; 
        Stamina = stamina;
        Breed = breed; 
        Gender = gender; 
        Size = size; 
        Chonk = chonk;
    }

    /// <summary>
    /// Get the gender of the dog
    /// </summary>
    /// <returns>The dog's gender</returns>
    public string GetGender() {
        if (Gender == 0) {
            return "Male";
        } else {
            return "Female";
        }
    }

    /// <summary>
    /// Get the size of the dog
    /// </summary>
    /// <returns>Size of dog</returns>
    public string GetSize() {
        try {
            switch (Size) {
                case 1:
                    return "Small";
                case 2:
                    return "Medium";
                case 3:
                    return "Large";
                case 4:
                    return "Extra large";
            }
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
        return "error";
    }
}