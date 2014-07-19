using System.Collections.Generic;
using System.Linq.Expressions;

namespace Online_Judge.DAL.Extensions
{
	/// <summary>
	/// ParameterRebinder
	/// </summary>
	public class ParameterRebinder : ExpressionVisitor
	{
		#region Dependencies

		private readonly Dictionary<ParameterExpression, ParameterExpression> _map;

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterRebinder"/> class.
		/// </summary>
		/// <param name="map">The map.</param>
		public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
		{
			_map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
		}

		#endregion

		#region Base Class Members

		/// <summary>
		/// Visits the parameter.
		/// </summary>
		/// <param name="p">The p.</param>
		/// <returns></returns>
		protected override Expression VisitParameter(ParameterExpression p)
		{
			ParameterExpression replacement;
			if (_map.TryGetValue(p, out replacement))
			{
				p = replacement;
			}
			return base.VisitParameter(p);
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Replaces the parameters.
		/// </summary>
		/// <param name="map">The map.</param>
		/// <param name="exp">The exp.</param>
		/// <returns></returns>
		public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
		{
			return new ParameterRebinder(map).Visit(exp);
		}

		#endregion
	}
}