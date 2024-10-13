import { mount } from '@vue/test-utils'
import { describe, it, expect, beforeEach, vi } from 'vitest'
import PricesDisplay from '../PricesDisplay.vue'

beforeEach(() => {
    vi.stubGlobal('import.meta', {
        env: {
        VITE_BACKEND_WS_URL: 'ws://test-backend-url',
        VITE_PRICES_WS: '/test',
        },
    });
    });

describe('PricesDisplay', () => {
    it('displays the price and timestamp', async () => {
    const wrapper = mount(PricesDisplay);
    
    // Simulate receiving a price update
    const price = {
        lastPrice: 1.23,
        lastUpdated: '2024-01-01',
        ask: 2,
        bid: 1
    };
    await wrapper.setData({ price: price });

    expect(wrapper.find('span.price').text()).toBe('1.23');
    expect(wrapper.find('span.time').text()).toBe('2024-01-01');
    expect(wrapper.find('span.bid').text()).toBe('1');
    expect(wrapper.find('span.ask').text()).toBe('2');
    });    
})
