class Track {
    int material;
    int length;

    /// <summary>
    /// Create a track
    /// </summary>
    /// <param name="material">See Track.cs to see a list of materials you can seledct.</param>
    /// <param name="length">Lenght of the track, cannot be longer than 25m</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Track(int material, int length) {
        if (material > 5) throw new ArgumentOutOfRangeException("material");
        if (length > 25) throw new ArgumentOutOfRangeException("length");
        this.material = material;
        this.length = length;
    }

    public string GetMaterial() {
        switch (material) {
            case 0:
                return "Grass";
            case 1:
                return "Concrete";
            case 2:
                return "Gravel";
            case 3:
                return "Asphalt";
            case 4:
                return "Sand";
            case 5:
                return "Snow";
            default:
                return "nAn";
        }
    }

}
