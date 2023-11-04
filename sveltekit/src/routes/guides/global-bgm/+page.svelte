<script>
	import { base } from '$app/paths';
	import Link from '$lib/Link.svelte';

	const lines = ['global_bgm["Period"]:', '  music = random_song(1, 10)', 'end'];
</script>

<h1>Overwrite Game BGM with Global BGM</h1>
<p>
	This guide is mostly intended for more advanced code music mods, although the first section covers
	a basic example of randomizing a song.
</p>
<h2>Requirements</h2>
<ul>
	<li>BGME Framework</li>
	<li><Link url="{base}/guides/create-mod">Created a Music Mod with BGME Framework</Link></li>
	<li>Have your music script file opened in a text editor</li>
</ul>
<h2>The Basics</h2>
<pre><code>{lines.join('\n')}</code></pre>
<p>Should be easy to understand by this point:</p>
<ul>
	<li>The block is a <b>global_bgm</b> block.</li>
	<li>
		The song we're changing is
		<b>Period</b>.
	</li>
	<li>
		Now whenever the game tries to play <b>Period</b>, it'll instead play a <b>Random Song</b> between
		BGM IDs 1 to 10.
	</li>
</ul>
<p>That's it for the basic use. Not too useful outside of randomizing songs.</p>
<h2>The Advanced Stuff</h2>
<p>
	But when you combine it with a code mod that takes advantage of <em>BGME Framework</em>'s live
	updating...
</p>
<p>
	While largely untested, in theory it's fairly simple. Hook a game function then update your mod's
	music script depending on the incoming data. Combine with <b>global_bgm</b> to replace the game's music
	based on whatever you want.
</p>
<b>General Ideas</b>
<ul>
	<li>Use custom battle themes depending on costumes, weapons, items, etc.</li>
	<li>Add new overworld music by checking the date and overwriting the overworld songs.</li>
	<li>Change other mod's music.</li>
</ul>
