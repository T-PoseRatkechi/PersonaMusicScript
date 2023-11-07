<script lang="ts">
	import { base } from '$app/paths';
	import { GAME_P3P, currentGame } from '$lib/Games';
	import Link from '$lib/Link.svelte';
	import Continue from '../Continue.svelte';
	import { locationExample } from '../Examples';
	import GameNotice from '../GameNotice.svelte';
	import Requirements from '../Requirements.svelte';

	$: code = $locationExample.code;
	$: settings = $locationExample.settings;
</script>

<h1>Location-based Battle Music</h1>
<p>
	Another cool, if not well known, feature is the ability to easily change battle music per
	location.
</p>
{#if $currentGame !== GAME_P3P}
	<p>
		Many thanks to <b>ZArkadia</b> for his work on categorizing each battle for Persona 4 Golden and
		Persona 5/Royal.
	</p>
	<Requirements />
	<h2>The Music Script</h2>
	<pre><code>{code?.join('\n')}</code></pre>
	<p>
		Just an encounter block with a collection. Super simple. This will make all battles in <em
			>{settings?.name}</em
		>
		play BGM ID {settings?.bgmId}.
	</p>
	<p>
		<b>How it works: </b>The battles in an area are pre-determined, so it's possible to change the
		battle music of an area <em>if</em> you know the ID of every battle in it. Thanks to ZArkadia, we
		do for P4G and P5 in the form of collections.
	</p>
	<p><Link url="{base}/docs/collections">A full list of collections can be found here.</Link></p>
	<h2>And That's It</h2>
	<GameNotice />
	<p>
		Add to your music script and save, add your new audio track for BGM ID {settings?.bgmId}, then
		test in-game if you want.
	</p>
{:else}
	<h2>Not Supported for Persona 3 Portable</h2>
	<p>
		Unfortunately, this feature is not supported for Persona 3 Portable. Since this feature relies
		on knowing every Encounter ID in an area, someone has to manually categorize each battle. This
		has only been done for Persona 4 Golden and Persona 5/Royal.
	</p>
{/if}
<Continue />
