<script lang="ts">
	import { base } from '$app/paths';
	import { GAME_P5R, currentGame } from '$lib/Games';
	import Link from '$lib/Link.svelte';
</script>

{#if $currentGame === GAME_P5R}
	<blockquote class="warning">
		<b>Persona 5 Royal</b>
		<p>
			Remember that <b>new</b> music have their BGM IDs shifted by 10,000 in music scripts. To play
			music file <b>100.adx</b>, you would use BGM ID <b>10100</b> (100 + 10000) in your music
			script. For details, see: <Link url="{base}/guides/new-music">Using New Music</Link>
		</p>
	</blockquote>
{/if}
