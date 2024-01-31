# Autoasocjator - Odszumianie Obrazów

## Opis Programu
Program umożliwia zaszumianie a następnie odszumianie jednego z 7 wgranych obrazów. Odszumianie możemy wielokrotnie powtarzać, aż uzyskamy zadowalający rezultat. Program powstał przy użyciu **perceptronów prostych** i **prostego modelu uczenia perceptronów**

Obrazy są wielkości 50x50, a każdy perceptron odpowiada za jeden piksel (łącznie 2500 perceptronów).

## Proces Uczenia Perceptronu
### Inicjalizacja zmiennych i wag
* Inicjalizacja wag perceptronu losowymi wartościami z zakresu [-0.01, 0.01].
* Inicjalizacja wartości theta (progu) perceptronu również losową wartością z zakresu [-0.01, 0.01].
* Ustalenie stałej uczenia learningEta na wartość 0.1.
* Inicjalizacja zmiennych pomocniczych, takich jak lifeTime (ilość iteracji bez błędu), bestLifeTime (najlepsza ilość iteracji bez błędu), bestTheta (najlepsza wartość theta), bestWeights (najlepsze wagi).

### Losowy wybór przykładu uczącego
* W pętli głównej (1000 iteracji) losowany jest indeks przykładu uczącego z listy examples.
* Przykład uczacy jest wybierany z folderu Assets gdzie znajduje się 7 obrazków.

### Ustalanie pożądanej odpowiedzi (O):
* Dla danego perceptronu, wartość O jest ustalana na 1, jeśli piksel w przykładzie uczącym dla danego perceptronu wynosi 1 (jest czarny), w przeciwnym razie O wynosi -1.

### Suma ważona i klasyfikacja
* Wyliczana jest suma ważona pikseli przykładu uczącego używając wag perceptronu.
* Na podstawie sumy ważonej i wartości theta, obliczana jest klasyfikacja -1 lub 1.

### Błąd (ERR) i dostosowywanie wag
* Obliczenie błędu jako różnicy między pożądaną odpowiedzią O a wynikiem klasyfikacji.
* Jeśli błąd jest różny od zera (klasyfikacja jest błędna), wagi są dostosowywane zgodnie z regułą perceptronową, gdzie η to współczynnik uczenia, ERR to błąd klasyfikacji, a x to wartość wejścia.:
> w = w + η * ERR * x
* Dodatkowo, wartość theta (progu) również jest dostosowywana:
> theta = theta + η * ERR

### Monitorowanie poprawności klasyfikacji
* Jeśli błąd jest równy zeru, zwiększana jest zmienna lifeTime
* Jeśli liczba iteracji bez błędu przekracza dotychczasowe maksimum (bestLifeTime), aktualizowane są wartości bestLifeTime, bestTheta, i bestWeights.

### Zakończenie uczenia dla danego perceptronu
* Po zakończeniu iteracji dla danego perceptronu, zapisywane są ostateczne wagi i theta dla tego perceptronu.
* Zaktualizowane wartości bestTheta i bestWeights są przenoszone do odpowiednich tablic, a następnie zwracane jako wynik funkcji dla danego perceptronu.

Proces ten powtarza się dla każdego perceptronu, co pozwala nauczyć perceptrony rozpoznawania wzorców na podstawie przykładów uczących. Uzyskane wagi są później używane do odszumiania obrazów podczas testowania perceptronów.
