--QUARTIL (1,3)
SELECT DISTINCT PERCENTILE_CONT(0.25) WITHIN GROUP(ORDER BY temperatura) OVER (PARTITION BY 1) FROM Pollo_Media_Minuto
SELECT DISTINCT PERCENTILE_CONT(0.75) WITHIN GROUP(ORDER BY temperatura) OVER (PARTITION BY 1) FROM Pollo_Media_Minuto

--MEDIANA e MEDIA
SELECT DISTINCT PERCENTILE_CONT(0.50) WITHIN GROUP(ORDER BY temperatura) OVER (PARTITION BY 1) FROM Pollo_Media_Minuto
SELECT ROUND(AVG(temperatura),2) FROM Pollo_Media_Minuto

--MODA
SELECT TOP 1 temperatura FROM Pollo_Media_Minuto GROUP BY temperatura HAVING COUNT(temperatura) > 1 ORDER BY temperatura DESC

--DESV
SELECT ROUND(STDEV(temperatura),2) FROM Pollo_Media_Minuto

--MAX
SELECT ROUND(MAX(temperatura),2) FROM Pollo_Media_Minuto
SELECT ROUND(MIN(temperatura),2) FROM Pollo_Media_Minuto