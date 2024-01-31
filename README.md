# Autoasocjator - Odszumianie Obrazów

## Opis Programu
Program umożliwia zaszumianie a następnie odszumianie jednego z 7 wgranych obrazów za pomocą sieci neuronowych. Odszumianie możemy wielokrotnie powtarzać, aż uzyskamy zadowalający rezultat. Program powstał przy użyciu **perceptronów prostych** i **prostego modelu uczenia perceptronów**

Obrazy są wielkości 50x50, a każdy neuron odpowiada za jeden piksel (łącznie 2500 neuronów).

## Proces Uczenia
### Inicjalizacja zmiennych i wag
* Inicjalizacja wag perceptronu (o rozmiarze 2500) losowymi wartościami z zakresu [-0.01, 0.01].
* Inicjalizacja wartości theta (progu) perceptronu również losową wartością z zakresu [-0.01, 0.01].
* Ustalenie stałej uczenia learningEta na wartość 0.1.
* Inicjalizacja zmiennych pomocniczych, takich jak lifeTime (ilość iteracji bez błędu), bestLifeTime (najlepsza ilość iteracji bez błędu), bestTheta (najlepsza wartość theta), bestWeights (najlepsze wagi).

### Losowy wybór przykładu uczącego
* W pętli głównej (1000 iteracji) losowany jest indeks przykładu uczącego z listy examples.
* Przykład uczacy jest wybierany z folderu Assets gdzie znajduje się 7 obrazków.

### Ustalanie pożądanej odpowiedzi (O):
* Dla danego perceptronu, wartość O jest ustalana na 1, jeśli piksel w przykładzie uczącym dla danego perceptronu wynosi 1, w przeciwnym razie O wynosi -1.
