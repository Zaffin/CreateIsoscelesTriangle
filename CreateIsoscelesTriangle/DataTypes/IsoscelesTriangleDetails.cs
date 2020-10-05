public struct IsoscelesTriangleDetails
{
    public double Aera { get; set; }
    public double Perimeter { get; set; }
    public double BaseAngle { get; set; }
    public double VertexAngle { get; set; }
    public double InscribedRadius { get; set; }
    public double CircumscribedRadius { get; set; }

    public IsoscelesTriangleDetails(double aera,
                                    double perimeter,
                                    double baseAngle,
                                    double vertexAngle,
                                    double inscribedRadius,
                                    double circumscribedRadius)
    {
        Aera = aera;
        Perimeter = perimeter;
        BaseAngle = baseAngle;
        VertexAngle = vertexAngle;
        InscribedRadius = inscribedRadius;
        CircumscribedRadius = circumscribedRadius;
    }
}