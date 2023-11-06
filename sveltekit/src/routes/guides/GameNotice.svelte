<script lang="ts">
	import { base } from '$app/paths';
	import { GAME_P3P, GAME_P5R, currentGame } from '$lib/Games';
	import Link from '$lib/Link.svelte';
</script>

{#if $currentGame === GAME_P5R}
	<blockquote class="warning">
		<b>{GAME_P5R}</b>
		<p>
			Remember that <b>new</b> music have their BGM IDs shifted by 10,000 in music scripts. To play
			music file <b>100.adx</b>, you would use BGM ID <b>10100</b> (100 + 10000) in your music
			script. For details, see: <Link url="{base}/guides/new-music">Using New Music</Link>
		</p>
	</blockquote>
{:else if $currentGame === GAME_P3P}
	<blockquote class="warning">
		<b>{GAME_P3P}</b>
		<p>Use BGM IDs that are at least 1000+. Using IDs below 1000 can cause crashes.</p>
	</blockquote>
{/if}
