# ProjectCoins
Small Unity game about collect coins

ТЗ:

**Карта**: произвольная

**Персонаж**: произвольный

**Монетки двух типов**: большая и маленькая
- большая монетка: +2 к счетчику. Большая подбирается по кнопке E(У).
* маленькая монетку: +1 к счетчику. Маленькая монетка подбирается просто проходя по ней.

**Радиус у монеток**: произвольный(в пределах разумного)

**Минимальное количество монеток**: 50.
Монетки появляются рандомно при запуске игры.


**Добавить препятствия** через которые игрок не может ходить, Препятствия спавнятся рандомно или расставлены вручную для усложнения сбора монеток.



В углу экрана сделать счётчик который пропадает через три секунды если монетки не подбираются:
- Flow счетчика:
  1. Игрок подходит к монетке
  2. Игрок подбирает монетку
  3. В углу экрана появляется счетчик(появляется в зоне видимости игрока)
  4. Если после поднятия монетки прошло 3 и более секунд - счетчик исчезает из зоны видимости

Перемещение персонажа при помощи WASD

*:Усложнение:
Сделать перемещение по стрелочной реализации мышки(Зажимаешь мышку - в какой стороне мышка - туда и идёт персонаж)


Игру залить на гитхаб: 
Сделать отдельный репозиторий для этой игры с Main и Develop ветками. Всю работу вести в ветке Develop, После завершения работы залить всё в Main.
