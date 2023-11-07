<script lang="ts">
	import { base } from '$app/paths';
	import Link from '$lib/Link.svelte';
	import Continue from '../Continue.svelte';
	import { bossExample } from '../Examples';
	import GameNotice from '../GameNotice.svelte';
	import Requirements from '../Requirements.svelte';

	$: code = $bossExample.code;
	$: settings = $bossExample.settings;
</script>

<h1>Custom Boss Music</h1>
<p>Another BGM mod often wanted, and also very simple to do.</p>
<Requirements />
<h2>The Music Script</h2>
<pre><code>{code?.join('\n')}</code></pre>
<p>
	Nothing new, just another Encounter Block with music being set. This will make <em
		>{settings?.name}'s</em
	>
	battle play BGM ID {settings?.bgmId}.
</p>
<p>
	The only notable thing is the use of the "collection" <em>{settings?.name}</em>. In this case, the
	"collection" only has one ID, {settings?.name}'s battle.
</p>
<p>
	These types of "collections" let you change the music of notable battles, without needing to know
	its <b>Encounter ID</b>.
</p>
<p><Link url="{base}/docs/collections">A full list of collections can be found here.</Link></p>
<h2>And That's It</h2>
<GameNotice />
<p>
	Add to your music script and save, add your new audio track for BGM ID {settings?.bgmId}, then
	test in-game if you want.
</p>
<Continue />
