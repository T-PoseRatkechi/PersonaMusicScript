import { writable } from 'svelte/store';

export const GAME_P4G: string = 'Persona 4 Golden';
export const GAME_P5R: string = 'Persona 5 Royal';
export const GAME_P3P: string = 'Persona 3 Portable';
export const allGames = [GAME_P5R, GAME_P4G, GAME_P3P];

export const currentGame = writable(GAME_P5R);
