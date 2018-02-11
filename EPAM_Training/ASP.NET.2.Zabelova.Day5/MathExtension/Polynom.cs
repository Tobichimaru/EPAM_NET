using System;
using System.Configuration;

namespace MathExtension
{
    /// <summary>
    /// Immutable type Polynom with real coefficients
    /// </summary>
    public class Polynom : IEquatable<Polynom>, ICloneable
    {
        #region Constructors
        static Polynom()
        {
            Epsilon = 0.000001;
        }

        /// <summary>
        /// Initializes a new instance of the Polynom class
        /// </summary>
        public Polynom()
        {
            Degree = 0;
            coeff = new double[1];
        }

        /// <summary>
        /// Initializes a new instance of the Polynom class that contains inputted elements and has sufficient capacity to accommodate the number of elements.
        /// </summary>
        /// <param name="inputCoeff">Coefficients to be copied to the Polynom</param>
        public Polynom(params double[] inputCoeff)
        {
            if (ReferenceEquals(inputCoeff, null)) throw new ArgumentNullException();
            if (inputCoeff.Length == 0)  throw new ArgumentException();
            
            int k = inputCoeff.Length - 1;
            while (Math.Abs(inputCoeff[k]) < Epsilon && k > 0) k--;
            Degree = k;
            
            coeff = new double[Degree + 1];
            for (int i = 0; i <= Degree; i++)
            {
                coeff[i] = inputCoeff[i];
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the Degree of Polynom
        /// </summary>
        public int Degree { get; private set; }
        #endregion

        #region Operators

        #region Math Operations
        /// <summary>
        /// Calculates sum of two Polynoms
        /// </summary>
        /// <param name="lhs">first Polynom</param>
        /// <param name="rhs">second Polynom</param>
        /// <returns>The sum of two polynoms which is also Polynom</returns>
        public static Polynom operator +(Polynom lhs, Polynom rhs)
        {
            if (ReferenceEquals(lhs, null)) throw new ArgumentNullException();
            return lhs.Addition(rhs);
        }

        /// <summary>
        /// Unary operator minus, Inverses coefficients of Polynom
        /// </summary>
        /// <param name="polynom">Polynom to be Inversed</param>
        /// <returns>Polynom with Inversed coefficients</returns>
        public static Polynom operator -(Polynom polynom)
        {
            if (ReferenceEquals(polynom, null)) throw new ArgumentNullException();
            return polynom.Inversion();
        }

        /// <summary>
        /// Calculates difference between two Polynoms
        /// </summary>
        /// <param name="lhs">first Polynom</param>
        /// <param name="rhs">second Polynom</param>
        /// <returns>The difference between two polynoms which is also Polynom</returns>
        public static Polynom operator -(Polynom lhs, Polynom rhs)
        {
            if (ReferenceEquals(lhs, null)) throw new ArgumentNullException();
            return lhs.Subtraction(rhs);
        }

        /// <summary>
        /// Multiplies Polynom by other Polynom
        /// </summary>
        /// <param name="lhs">First polynom to be multiplied</param>
        /// <param name="rhs">Second polynom to be multiplied</param>
        /// <returns>Product of Polynoms</returns>
        public static Polynom operator *(Polynom lhs, Polynom rhs)
        {
            if (ReferenceEquals(lhs, null)) throw new ArgumentNullException();
            return lhs.Multiplication(rhs);
        }

        /// <summary>
        /// Divide Polynom by other Polynom
        /// </summary>
        /// <param name="lhs">Divident</param>
        /// <param name="rhs">Divisor</param>
        /// <returns>The quotient from the division</returns>
        public static Polynom operator /(Polynom lhs, Polynom rhs)
        {
            if (ReferenceEquals(lhs, null)) throw new ArgumentNullException();
            return lhs.Divide(rhs);
        }

        /// <summary>
        /// Divide Polynom by other Polynom
        /// </summary>
        /// <param name="lhs">Divident</param>
        /// <param name="rhs">Divisor</param>
        /// <returns>The remainder from the division</returns>
        public static Polynom operator %(Polynom lhs, Polynom rhs)
        {
            if (ReferenceEquals(lhs, null)) throw new ArgumentNullException();
            return lhs.Mod(rhs);
        }
        #endregion

        #region Conversion Operators
        /// <summary>
        /// User-defined conversion from double array to Polynom
        /// </summary>
        /// <param name="arr">double array of coefficients</param>
        /// <returns>Polynom with coefficients of the array</returns>
        public static implicit operator Polynom(double[] arr)
        {
            return new Polynom(arr);
        }

        /// <summary>
        /// User-defined conversion from double to Polynom
        /// </summary>
        /// <param name="alpha">double coefficient</param>
        /// <returns>>Polynom with inputted coefficient</returns>
        public static implicit operator Polynom(double alpha)
        {
            return new Polynom(alpha);
        }

        /// <summary>
        /// User-defined type conversion operator that must be invoked with a cast
        /// </summary>
        /// <param name="polynom">Polynom to be casted to double</param>
        /// <returns>double array of coefficients</returns>
        public static explicit operator double[](Polynom polynom)
        {
            return polynom.coeff;
        }
        #endregion

        #region Equality Operators
        /// <summary>
        /// Check on equality two instances of Polynom
        /// </summary>
        /// <param name="lhs">first polynom</param>
        /// <param name="rhs">second polynom</param>
        /// <returns>true, if polynoms are equal, else false</returns>
        public static bool operator ==(Polynom lhs, Polynom rhs)
        {
            if (ReferenceEquals(lhs, null)) return false;
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Check on enequality two instances of Polynom
        /// </summary>
        /// <param name="lhs">first polynom</param>
        /// <param name="rhs">second polynom</param>
        /// <returns>true, if polynoms are not equal, else false</returns>
        public static bool operator !=(Polynom lhs, Polynom rhs)
        {
            return !(lhs == rhs);
        }
        #endregion
        
        #endregion

        #region Public Methods

        #region Operator Methods
        /// <summary>
        /// Calculates sum of two Polynoms
        /// </summary>
        /// <param name="polynom">Polynom to be added</param>
        /// <returns>The sum of two polynoms which is also Polynom</returns>
        public Polynom Add(Polynom polynom)
        {
            return Addition(polynom);
        }

        /// <summary>
        /// Calculates difference between two Polynoms
        /// </summary>
        /// <param name="polynom">Polynom to be substracted</param>
        /// <returns>The difference between two polynoms which is also Polynom</returns>
        public Polynom Subtract(Polynom polynom)
        {
            return Subtraction(polynom);
        }

        /// <summary>
        /// Inverses coefficients of Polynom
        /// </summary>
        /// <returns>Polynom with Inversed coefficients</returns>
        public Polynom Inverse()
        {
            return Inversion();
        }

        /// <summary>
        /// Multiplies this polynom by other Polynom
        /// </summary>
        /// <param name="polynom">Polynom to be multiplied</param>
        /// <returns>Product of Polynoms</returns>
        public Polynom Multiply(Polynom polynom)
        {
            return Multiplication(polynom);
        }

        /// <summary>
        /// Divide Polynom by other Polynom with remainder
        /// </summary>
        /// <param name="divisor"></param>
        /// <param name="remainder"></param>
        /// <returns>The quotient from the division</returns>
        public Polynom Divide(Polynom divisor)
        {
            Polynom remainder;
            return Division(divisor, out remainder);
        }

        /// <summary>
        /// Divide Polynom by other Polynom with remainder
        /// </summary>
        /// <param name="divisor"></param>
        /// <param name="remainder"></param>
        /// <returns>The remainder from the division</returns>
        public Polynom Mod(Polynom divisor)
        {
            Polynom remainder;
            Division(divisor, out remainder);
            return remainder;
        }
        #endregion

        #region Other Methods
        /// <summary>
        /// Calculates value of the polynom
        /// </summary>
        /// <param name="value">value of the variable</param>
        /// <returns>Polynoms value</returns>
        public double Calculate(double value)
        {
            double result = 0;
            for (int i = 0; i <= Degree; i++)
            {
                result += Math.Pow(value, i)*coeff[i];
            }
            return result;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// Clones instance of Polynom
        /// </summary>
        /// <returns>New instance of Polynom</returns>
        public Polynom Clone()
        {
            return new Polynom(coeff);
        }

        public override bool Equals(Object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;

            Polynom p = obj as Polynom;
            if (p == null) return false;
            Polynom polynom = (Polynom)obj;
            return Equals(polynom);
        }

        public bool Equals(Polynom polynom)
        {
            if (ReferenceEquals(polynom, null)) return false;
            if (ReferenceEquals(polynom, this)) return true;
            if (Degree != polynom.Degree) return false;

            for (int i = 0; i <= Degree; i++)
            {
                if (Math.Abs(coeff[i] - polynom[i]) > Epsilon) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((coeff != null ? coeff.GetHashCode() : 0) * 397) ^ Degree;
            }
        }

        public override string ToString()
        {
            string result = "";
            int i = Degree;
            while (i >= 0)
            {
                result += String.Format("{0:F20}", coeff[i].ToString()) + "*x^" + i.ToString();
                if (i > 0) result += " + ";
                i--;
            }
            return result;
        }
        #endregion

        #endregion

        #region Private Methods
        private Polynom Addition(Polynom polynom)
        {
            if (ReferenceEquals(polynom, null)) throw new ArgumentNullException();

            int resultDegree = Math.Max(Degree, polynom.Degree);
            double[] resultCoeff = new double[resultDegree + 1];

            for (int i = 0; i <= resultDegree; i++)
            {
                resultCoeff[i] = (i <= Degree) ? coeff[i] : 0;
                resultCoeff[i] += (i <= polynom.Degree) ? polynom[i] : 0;
            }

            return new Polynom(resultCoeff); 
        }

        private Polynom Subtraction(Polynom polynom)
        {
            if (ReferenceEquals(polynom, null)) throw new ArgumentNullException();
            return Addition(polynom.Inversion());
        }

        private Polynom Inversion()
        {
            double[] resultCoeff = new double[Degree + 1];
            for (int i = 0; i <= Degree; i++)
            {
                resultCoeff[i] = -coeff[i];
            }

            return new Polynom(resultCoeff);
        }

        private Polynom Multiplication(Polynom polynom)
        {
            if (ReferenceEquals(polynom, null)) throw new ArgumentNullException();

            int resultDegree = Degree + polynom.Degree;
            double[] resultCoeff = new double[resultDegree + 1];
            for (int i = 0; i <= Degree; i++)
            {
                for (int j = 0; j <= polynom.Degree; j++)
                {
                    resultCoeff[i + j] += coeff[i] * polynom[j];
                }
            }

            return new Polynom(resultCoeff);
        }

        private Polynom Division(Polynom divisor, out Polynom remainder)
        {
            if (ReferenceEquals(divisor, null)) throw new ArgumentNullException();

            int quotientDegree = Degree - divisor.Degree;
            double[] quotientCoeff = new double[quotientDegree + 1];
            double[] remainderCoeff = new double[Degree + 1];
            for (int i = 0; i <= Degree; i++)
            {
                remainderCoeff[i] = coeff[i];
            }

            for (int i = 0; i <= quotientDegree; i++)
            {
                double otherCoeff = remainderCoeff[Degree - i]/divisor[divisor.Degree];
                quotientCoeff[quotientDegree - i] = otherCoeff;
                for (int j = 0; j <= divisor.Degree; j++)
                {
                    remainderCoeff[Degree - i - j] -= otherCoeff*divisor[divisor.Degree - j];
                }
            }

            remainder = new Polynom(remainderCoeff);
            return new Polynom(quotientCoeff);
        }

        #endregion

        #region Private Indexator
        private double this[int i]
        {
            get
            {
                if (i > Degree || i < 0) throw new ArgumentOutOfRangeException();
                return coeff[i];
            }
        }
        #endregion
        
        #region Private Properties and Fields
        private readonly double[] coeff;
        private static double Epsilon { get; set; }
        #endregion
    }
}