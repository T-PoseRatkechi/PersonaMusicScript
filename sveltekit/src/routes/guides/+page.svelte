<script lang="ts">
	import { base } from '$app/paths';
	import Link from '$lib/Link.svelte';

	interface Guide {
		name: string;
		description: string;
		url: string;
	}

	const guides: Guide[] = [
		{
			name: 'Creating a Music Mod',
			description:
				"The place to start if you're new to creating music mods, whether or not you're using BGME Framework.",
			url: `${base}/guides/create-mod`
		},
		{
			name: 'Phos Music Manager',
			description:
				'Set up Phos Music Manager for your game to simplify replacing (and adding) music.',
			url: `${base}/guides/music-manager`
		},
		{
			name: 'Using New Music',
			description: 'Goes over how to add and use new music for each game.',
			url: `${base}/guides/new-music`
		},
		{
			name: 'Adding Randomized BGM',
			description: 'Explains how to add randomized BGM to battles.',
			url: `${base}/guides/randomized-bgm`
		},
		{
			name: 'Custom Boss Music',
			description: 'Give a boss battle a custom song.',
			url: `${base}/guides/boss-music`
		},
		{
			name: 'Location-based Battle Music',
			description: 'Customize the music used in battles depending on where the battle is.',
			url: `${base}/guides/location-bgm`
		},
		{
			name: 'Custom Battle BGM (Advantage, Disadvantage, Victory)',
			description:
				'Customize the music used in battles depending on context: normal, advantage, disadvantage.',
			url: `${base}/guides/battle-bgm`
		},
		{
			name: 'Overwrite Game BGM with Global BGM',
			description:
				'A powerful feature is the ability to hook and redirect any song. From randomizing a song to adding new music features.',
			url: `${base}/guides/global-bgm`
		},
		{
			name: 'Other Features',
			description: 'Advanced features with more niche uses.',
			url: `${base}/guides/other-features`
		}
	];
</script>

<h1>Guides</h1>
<ul>
	{#each guides as guide}
		<li>
			<Link url={guide.url}><b>{guide.name}</b></Link>
			<div>{guide.description}</div>
		</li>
	{/each}
</ul>
