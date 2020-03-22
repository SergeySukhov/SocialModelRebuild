using SocialModelRebuild.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialModelRebuild.Libraries
{
    public static class CellModelLibrary
    {
        public static CellModel CreateCalssicModel(int N)
        {
            var cellModel = new CellModel(N);

            cellModel.FindFriends = CellFrinedsFindingLibrary.FindFriendsSimple;
            cellModel.CalculateInputImpact = CellCalculateInputImpactLibrary.CalculateInputImpactSimple;
            cellModel.CalculateOwnOpinion = CellCalculateOwnOpinionLibrary.CalculateOwnOpinionSimple;

            cellModel.SetupModel();


            SetModelParamsWithRandom(cellModel, 35, 35, 30);

            cellModel.FindFriends(cellModel.MatrixCell, cellModel.LinkModel, cellModel.LeftBorder, cellModel.RightBorder);
            cellModel.FirstIter = new SavingCellModel().SaveCellModel(cellModel);
            return cellModel;
        }

        public static CellModel CreateSpecialModel()
        {
            var cellModel = new CellModel(60);

            cellModel.FindFriends = CellFrinedsFindingLibrary.FindFriendsSimple; // Определяем функцию для установления связей (сейчас связи по Муру)
            cellModel.CalculateInputImpact = CellCalculateInputImpactLibrary.CalculateInputImpactSimple; // Определяем функцию для подсчета входящего вляиния и его измения 
            cellModel.CalculateOwnOpinion = CellCalculateOwnOpinionLibrary.CalculateOwnOpinionSimple; // Определяем функцию для расчета собственного мнения

            cellModel.SetupModel(); // Подготавливаем модель: создаем клетки, записываем их в общий список и матрицу

            // ---------------------------- задаем распределение клеток в модели назначением параметров

            for(int i = 0; i < cellModel.MatrixCell.Length; i++) // проходим по матрице
                for(int j = 0; j < cellModel.MatrixCell[i].Length; j++)
                {
                    // записываем параметры по умолчанию (синие)
                    SetCellParams(cellModel.MatrixCell[i][j], 40, 1, 1, -1, 2); // Задаем параметры клетке матрицы (см. описание функции)

                    // перезапишем нужные клетки
                    if (i < 25 && j < 25) // начиная от 0 и до 25 строки И начиная от 0 и до 25 столбца...
                    {
                        SetCellParams(cellModel.MatrixCell[i][j], 50, 1, 1, 1, 2); // Задаем параметры клетке матрицы (см. описание функции)
                    }

                    if (i >= 25 && i < 27 && j <15) // для 25 и 26 столбца (отсчет от 0) и для 15 строк...
                    {
                        SetCellParams(cellModel.MatrixCell[i][j], 10, 1, 1, 1, 2); // Задаем параметры клетке матрицы (см. описание функции)
                    }


                    // здесь можно задать дополнительное переписываение п=параметров клеток
                    // ...
                }


            // ----------------------------

            cellModel.FindFriends(cellModel.MatrixCell, cellModel.LinkModel, cellModel.LeftBorder, cellModel.RightBorder);
            cellModel.FirstIter = new SavingCellModel().SaveCellModel(cellModel);
            return cellModel;
        }

        private static void SetModelParamsWithRandom(CellModel cellModel, int redPercent, int bluePercent, int greyPercent)
        {
            Random random = new Random();

            for (int i = 0; i < cellModel.AllCells.Count; i++)
            {
                double randomNum = random.NextDouble();

                if (redPercent > randomNum * 100)
                {
                    SetCellParams(cellModel.AllCells[i], 1, 2);
                    continue;
                }
                if (redPercent + bluePercent > randomNum * 100)
                {
                    SetCellParams(cellModel.AllCells[i], -1, 2);
                    continue;
                }
                if (redPercent + bluePercent + greyPercent > randomNum * 100)
                {
                    SetCellParams(cellModel.AllCells[i], 2, 2);
                    continue;
                }
                SetCellParams(cellModel.AllCells[i], 0, 0);
            }


        }
        private static void SetCellParams(Cell cell, int d, int M)
        {
            cell.d = d;
            cell.U = d * 30;
            if (d == 2) cell.U = 0;
            cell.K = 1;
            cell.S = 1;
            cell.L = 0;
            cell.M = M;
            if (d == 0) M = 0;
        }

        /// <summary>
        /// Запись параметров клетки
        /// </summary>
        /// <param name="cell">Изменяемая клетка</param>
        /// <param name="U">Начальное влияние (по умолчанию 30)</param>
        /// <param name="K">Исходящее влияние</param>
        /// <param name="S">Коэффициент забываения</param>
        /// <param name="d">Направленность (1 - красная, -1 синяя, 2 - серая, 0 - белая)</param>
        /// <param name="M">Радиус действия</param>
        private static void SetCellParams(Cell cell, double? U, double? K, double? S, int d, int M)
        {
            cell.d = d;

            cell.U = U.HasValue ? U.Value : 30;
            cell.U *= d;
            if (d == 2) cell.U = 0;

            cell.K = K.HasValue ? K.Value : 1;
            cell.S = S.HasValue ? S.Value : 1;

            cell.M = M;
            if (d == 0) M = 0;
        }
    }
}
