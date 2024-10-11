<script setup>
    import { ref, computed, onMounted } from 'vue';

    const price = ref({
        lastPrice: 0,
        lastUpdated: '',
        ask: 0,
        bid: 0
    });

    const previousPrice = ref({
        lastPrice: 0,
        lastUpdated: '',
        ask: 0,
        bid: 0
    });

    const fromCurrency = 'USD';
    const toCurrency = 'EUR';

    const priceClass = computed(() => ({
        'price-up': price.value.lastPrice > previousPrice.value.lastPrice,
        'price-down': price.value.lastPrice < previousPrice.value.lastPrice,
    }));

    function updatePrice(newPrice) {
        previousPrice.value = price.value;
        price.value = newPrice;
    }

    const socketUrl = import.meta.env.VITE_BACKEND_URL + import.meta.env.VITE_PRICES_WS;
    let webSocket;// = connectWebSocket();

    function connectWebSocket() {
        const socket = new WebSocket(socketUrl);
        socket.onopen = () => {
            console.log('WebSocket connection established');

            socket.send(JSON.stringify({ fromCurrency : fromCurrency, toCurrency: toCurrency }));
        };
        socket.onmessage = (event) => {
            console.log('WebSocket message received', event.data);
            const data = JSON.parse(event.data);
            updatePrice(data);
        };
        socket.onerror = (error) => {
            console.error('WebSocket Error:', error);
        };
        socket.onclose = () => {
            console.log('WebSocket connection closed');
        };

        return socket;
    }

    onMounted(() => {
        webSocket = connectWebSocket();
    });
</script>

<template>
    <div class="price-display">
        <div class="item-row">
            <span class="currency">{{ fromCurrency }}</span> / <span class="currency">{{ toCurrency }}</span>
        </div>
        <div class="item-row">
            <span>Last price:</span><span class="price" :class="priceClass">{{ price.lastPrice }}</span>
        </div>
        <div class="item-row">
            <span>Bid:</span><span class="price" :class="priceClass">{{ price.bid }}</span> / <span>Ask:</span><span class="price" :class="priceClass">{{ price.ask }}</span>
        </div>
        <div class="item-row">
            <span>Time updated:</span><span class="time">{{ new Date(price.lastUpdated).toLocaleTimeString() }}</span>
        </div>
    </div>
 </template>

<style scoped>
    .currency {
        background-color:#14835b;
        color: #fff;
        padding: 4px 10px;
        border: solid 1px #000;
        border-radius: 6px;
    }
    .item-row {
        font-size: 1.5rem;
        margin: 8px 0;
    }
    .price, .time {
        font-weight: bold;
        margin-top: 2px;
        margin-left: 1rem;
    }
    .price-up {
        color: green;
    }
    .price-down {
        color: red;
    }
</style>