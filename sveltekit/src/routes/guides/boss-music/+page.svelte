<script>
	import { base } from '$app/paths';
	import Link from '$lib/Link.svelte';

	const lines = ['encounter["Shadow Yosuke"]:', '  music = 698', 'end'];
</script>

<h1>Custom Boss Music</h1>
<p>Another BGM mod often wanted, and also very simple to do.</p>
<blockquote>
	This guide builds off the previous one: <Link url="{base}/guides/randomized-bgm"
		>Adding Randomized BGM</Link
	>. If you don't want random BGM then you can just read through it and come back.
</blockquote>
<h2>Requirements</h2>
<ul>
	<li>BGME Framework</li>
	<li><Link url="{base}/guides/create-mod">Created a Music Mod with BGME Framework</Link></li>
	<li>Have your music script file opened in a text editor</li>
</ul>
<h2>The Music Script</h2>
<pre><code>{lines.join('\n')}</code></pre>
<p>
	Light spoilers for Persona 4... Nothing new, just another Encounter Block with music being set.
	This will make <em>Shadow Yosuke's</em> battle play BGM ID 698.
</p>
<p>
	The only notable thing is the use of the "collection" <em>Shadow Yosuke</em>. In this case, the
	"collection" only has one item, Yosuke's battle.
</p>
<p>
	These types of "collections" let you change the music of notable battles, without needing to know
	its <b>Encounter ID</b>.
</p>
<p><Link url="{base}/docs/collections">A full list of collections can be found here.</Link></p>
<h2>And That's It</h2>
<p>
	Add to your music script and save, add your new audio track for BGM ID 698, then test in-game if
	you want.
</p>
<p>
	<b
		>Continue: <Link url="{base}/guides/battle-bgm"
			>Custom Battle BGM (Advantage, Disadvantage, Victory)</Link
		></b
	>
</p>
<p>
	For other features, such as <b>Floor BGM</b> and <b>Event BGM</b>, <Link url="{base}/docs"
		>read the docs.</Link
	>
</p>
