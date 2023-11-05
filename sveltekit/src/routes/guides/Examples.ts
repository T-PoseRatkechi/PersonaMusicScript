import * as games from '$lib/Games';
import { currentGame } from '$lib/Games';
import { derived, get } from 'svelte/store';

const randomSettings = new Map<string, RandomSong>();
randomSettings.set(games.GAME_P5R, { minId: 10000, maxId: 10009 });
randomSettings.set(games.GAME_P4G, { minId: 700, maxId: 709 });
randomSettings.set(games.GAME_P3P, { minId: 400, maxId: 409 });

export const randomSongExample = derived(currentGame, ($currentGame) => {
	const settings = randomSettings.get($currentGame);
	const examples = {
		code: [
			`const myRandomBgm = random_song(${settings?.minId}, ${settings?.maxId})`,
			'',
			'encounter["Normal Battles"]:',
			'  music = myRandomBgm',
			'end'
		],
		func: `random_song(${settings?.minId}, ${settings?.maxId})`,
		settings
	};

	return examples;
});

const bossSettings = new Map<string, Encounter>();
bossSettings.set(games.GAME_P5R, { name: 'The Reaper', bgmId: 10100 });
bossSettings.set(games.GAME_P4G, { name: 'Shadow Yosuke', bgmId: 750 });
bossSettings.set(games.GAME_P3P, { name: 'The Reaper', bgmId: 500 });

export const bossExample = derived(currentGame, ($currentGame) => {
	const settings = bossSettings.get($currentGame);
	const examples = {
		code: [`encounter["${settings?.name}"]`, `  music = ${settings?.bgmId}`, 'end'],
		settings
	};

	return examples;
});

export const battleBgmExample = derived(currentGame, ($currentGame) => {
	const previousExample = get(randomSongExample);

	const random2: RandomSong = {
		minId: previousExample.settings!.minId + 10,
		maxId: previousExample.settings!.maxId + 10
	};

	const song = getDisadvantageSong($currentGame);
	const songFunc = `song("${song}")`;
	const func = `battle_bgm(myRandomBgm, myRandomBgm2, ${songFunc})`;
	const newCode = [
		`const myRandomBgm = ${previousExample.func}`,
		`const myRandomBgm2 = random_song(${random2.minId}, ${random2.maxId})`,
		'',
		'encounter["Normal Battles"]:',
		`  music = ${func}`,
		'end'
	];

	const victorySong = getVictorySong($currentGame);
	const victorySongFunc = `song("${victorySong}")`;
	const newCode2 = [
		`const myRandomBgm = ${previousExample.func}`,
		`const myRandomBgm2 = random_song(${random2.minId}, ${random2.maxId})`,
		'',
		'encounter["Normal Battles"]:',
		`  music = ${func}`,
		`  victory_advantage_bgm = ${victorySongFunc}`,
		'end'
	];

	return {
		currentCode: previousExample.code,
		newCode,
		song,
		songFunc,
		newCode2,
		victorySong
	};
});

function getDisadvantageSong(game: string) {
	switch (game) {
		case games.GAME_P5R:
			return 'Blooming Villain';
		case games.GAME_P4G:
			return "I'll Face Myself -Battle-";
		case games.GAME_P3P:
			return 'Crisis';
		default:
			return 'specialist';
	}
}

function getVictorySong(game: string) {
	switch (game) {
		case games.GAME_P5R:
			return 'Big Bang Burger March';
		case games.GAME_P4G:
			return 'specialist';
		case games.GAME_P3P:
			return "When the Moon's Reaching Out Stars";
		default:
			return 'specialist';
	}
}
