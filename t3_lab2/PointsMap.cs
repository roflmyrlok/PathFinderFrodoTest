﻿using System.Collections.Generic;
using System.Linq;

namespace t3_lab2
{
	public class ClassMap
	{
		public List<List<ModernPoints>> ListOfList;
		private int _width;
		private int _height;

		public void SetMap(string[,] newMap, int width, int height)
		{
			this._width = width - 1;
			this._height = height - 1;
			ListOfList = new List<List<ModernPoints>>();
			for (int row = 0; row < _height; row++)
			{
				ListOfList.Add(new List<ModernPoints>());
				for (int column = 0; column < _width; column++)
				{
					ModernPoints newPoint = new ModernPoints();
					newPoint.SetPoint(column, row, newMap[column, row]);
					ListOfList[row].Add(newPoint);
				}
			}
		}

		public int LenWidth()
		{
			return _width;
		}
		public int LenHeight()
		{
			return _height;
		}

		public Queue<ModernPoints> GetPointsNearby(ModernPoints point ,bool coolerPoints = false)
		{
			int offset = 1;
			var result = new Queue<ModernPoints>();
			TryAddWithOffset(offset, 0);
			TryAddWithOffset(-offset, 0);
			TryAddWithOffset(0, offset);
			TryAddWithOffset(0, -offset);
			if (coolerPoints)
			{
				var coolerResult = new Queue<ModernPoints>();
				var dictForSockets = new Dictionary<ModernPoints, int>();

				foreach (var socket in result)
				{
					var x = _width - socket.GetColumn() + _height - socket.GetRow();
					dictForSockets.Add(socket, x);
				}
				var keyR = dictForSockets.Min(x => x.Value);
				var myKey = dictForSockets.FirstOrDefault(x => x.Value == keyR).Key;
					coolerResult.Enqueue(myKey);
					dictForSockets.Remove(myKey);
					foreach (var key in dictForSockets)
					{
						coolerResult.Enqueue(key.Key);
					}
					return coolerResult;
			}
			return result;
				void TryAddWithOffset(int offsetX, int offsetY)
			{
				var newColumn = point.GetColumn() + offsetX;
				var newRow = point.GetRow() + offsetY;
				if (newColumn >= 0 && newRow >= 0 && newColumn < _width && newRow < _height)
				{
					if (ListOfList[newRow][newColumn].GetValue() != "█")
					{
						result.Enqueue(ListOfList[newRow][newColumn]);
					}
				}
			}
		}
	}
}


	